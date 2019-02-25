using System.Windows.Input;
using GNW.ILS.WPF.Helpers;
using GNW.ILS.WPF.Utility;
using GNW.ILS.WPF.Views;

namespace GNW.ILS.WPF.ViewModels
{
    public class DockingViewModel : ViewModelBase
    {
        public ICommand ClientCommand { get; set; }

        public ICommand MatterCommand { get; set; }

        public ICommand ClientSearchCommand { get; set; }

        public ICommand MatterSearchCommand { get; set; }

        public DockingViewModel()
        {
            ClientCommand = new DelegateCommand(ExecuteClientCommand);
            MatterCommand = new DelegateCommand(ExecuteMatterCommand);
            ClientSearchCommand = new DelegateCommand(ExecuteClientSearchCommand);
            MatterSearchCommand = new DelegateCommand(ExecuteMatterSearchCommand);

        }

        private void ExecuteClientCommand(object obj)
        {
            Common.AddViewToGrid(new ClientListView());
        }

        private void ExecuteMatterCommand(object obj)
        {
            Common.AddViewToGrid(new ClientView());
        }

        private void ExecuteClientSearchCommand(object obj)
        {
            Common.AddViewToGrid(new CompanyMaster());
        }

        private void ExecuteMatterSearchCommand(object obj)
        {
            Common.AddViewToGrid(new TilesView());
        }
    }
}
