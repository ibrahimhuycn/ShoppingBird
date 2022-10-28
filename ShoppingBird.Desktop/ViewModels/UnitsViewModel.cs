using AutoMapper;
using ShoppingBird.Desktop.Helpers;
using ShoppingBird.Desktop.Models;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public class UnitsViewModel : NotifyBase, IUnitsViewModel
    {
        private readonly IUnitsIO _unitsIO;
        private readonly IMapper _mapper;
        private int _selectedUnitId;
        private string _selectedUnit;
        private string _selectedUnitDescription;

        private event EventHandler OnInitialize;
        public UnitsViewModel(IUnitsIO unitsIO, IMapper mapper)
        {
            _unitsIO = unitsIO;
            _mapper = mapper;
            AllUnits = new BindingList<UnitsModel>();

            OnInitialize += UnitsViewModel_OnInitialize;
            OnInitialize?.Invoke(this, EventArgs.Empty);
        }

        #region Public properties
        public BindingList<UnitsModel> AllUnits { get; set; }
        public int SelectedUnitId
        {
            get => _selectedUnitId; set
            {
                _selectedUnitId = value;
                OnPropertyChanged();
            }
        }
        public string SelectedUnit
        {
            get => _selectedUnit; set
            {
                _selectedUnit = value;
                OnPropertyChanged();
            }
        }
        public string SelectedUnitDescription
        {
            get => _selectedUnitDescription; set
            {
                _selectedUnitDescription = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Public Methods
        public async Task SaveUnitAsync()
        {
            if (string.IsNullOrEmpty(SelectedUnit)) { throw new ArgumentException("Unit cannot be empty."); }
            if (string.IsNullOrEmpty(SelectedUnitDescription)) { throw new ArgumentException("Unit description cannot be empty."); }

            if (SelectedUnitId < 0)
            {
                var inserted = await _unitsIO.InsertUnitAsync(SelectedUnit, SelectedUnitDescription);
                var mapped = _mapper.Map<UnitsModel>(inserted);
                DisplayInsertedOrUpdatedUnits(mapped);
            }

            if (SelectedUnitId > 0)
            {
                var updated = await _unitsIO.UpdateUnitAsync(new Fly.Models.UnitsModel() { Id = SelectedUnitId, Unit = SelectedUnit, Description = SelectedUnitDescription });
                var mapped = _mapper.Map<UnitsModel>(updated);
                DisplayInsertedOrUpdatedUnits(mapped);
            }
        }
        public void SetUnitInsertMode()
        {
            SelectedUnitId = -1;
            SelectedUnit = "";
            SelectedUnitDescription = "";
        }
        #endregion

        #region Private Methods
        private async void UnitsViewModel_OnInitialize(object sender, EventArgs e)
        {
            await LoadAllUnitsAsync();
        }

        private async Task LoadAllUnitsAsync()
        {
            try
            {
                AllUnits.Clear();
                var units = await _unitsIO.LoadAllUnitsAsync();
                if (units is null) { return; }

                var mapped = _mapper.Map<List<UnitsModel>>(units);
                foreach (var item in mapped)
                {
                    AllUnits.Add(item);
                }
            }
            catch (Exception ex)
            {
                Helpers.NotificationHelper.ShowMessage(ex, "Cannot Load Units");
            }
        }


        private void DisplayInsertedOrUpdatedUnits(UnitsModel unit)
        {
            SelectedUnitId = unit.Id;
            SelectedUnit = unit.Unit;
            SelectedUnitDescription = unit.Description;

            var displayedUnit = AllUnits.FirstOrDefault(x => x.Id == unit.Id);
            if (displayedUnit is null) { AllUnits.Add(unit); }
            else
            {
                displayedUnit.Unit = unit.Unit;
                displayedUnit.Description = unit.Description;
            }
        }

        #endregion
    }
}
