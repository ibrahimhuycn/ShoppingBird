using ShoppingBird.Desktop.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public interface IUnitsViewModel
    {
        BindingList<UnitsModel> AllUnits { get; set; }
        string SelectedUnit { get; set; }
        string SelectedUnitDescription { get; set; }
        int SelectedUnitId { get; set; }

        Task SaveUnitAsync();
        void SetUnitInsertMode();
    }
}