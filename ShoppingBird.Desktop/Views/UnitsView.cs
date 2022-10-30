using DevExpress.XtraEditors;
using ShoppingBird.Desktop.Models;
using ShoppingBird.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingBird.Desktop.Views
{
    public partial class UnitsView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IUnitsViewModel _viewModel;

        public UnitsView(IUnitsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();
            gridViewUnits.FocusedRowChanged += GridViewUnits_FocusedRowChanged;
            simpleButtonInsertUnit.Click += SimpleButtonInsertUnit_Click;
            simpleButtonSaveUnit.Click += SimpleButtonSaveUnit_Click;
            KeyUp += UnitsView_KeyUpAsync;
        }

        private async void SimpleButtonSaveUnit_Click(object sender, EventArgs e)
        {
            await SaveUnitAsync(Keys.F6);
        }

        private void SimpleButtonInsertUnit_Click(object sender, EventArgs e)
        {
            SetUnitInsertMode(Keys.Insert);
        }

        private async void UnitsView_KeyUpAsync(object sender, KeyEventArgs e)
        {
            SetUnitInsertMode(e.KeyCode);
            await SaveUnitAsync(e.KeyCode);
        }

        private async Task SaveUnitAsync(Keys keyCode)
        {
            if (keyCode == Keys.F6)
            {
                await _viewModel.SaveUnitAsync();
            }
        }

        private void SetUnitInsertMode(Keys keyCode)
        {
            if (keyCode == Keys.Insert)
            {
                _viewModel.SetUnitInsertMode();
            }
        }

        private void GridViewUnits_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var selectedUnit = (UnitsModel)gridViewUnits.GetRow(e.FocusedRowHandle);
            _viewModel.SelectedUnitId = selectedUnit.Id;
            _viewModel.SelectedUnit = selectedUnit.Unit;
            _viewModel.SelectedUnitDescription = selectedUnit.Description;
        }

        private void InitializeBinding()
        {
            //gridControlUnits
            gridControlUnits.DataSource = _viewModel.AllUnits;

            textEditUnitId.DataBindings.Add(new Binding("Text",_viewModel, nameof(_viewModel.SelectedUnitId),
                false, DataSourceUpdateMode.OnPropertyChanged));
            textEditUnit.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedUnit),
                false, DataSourceUpdateMode.OnPropertyChanged));
            textEditUnitDescription.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedUnitDescription),
                false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}