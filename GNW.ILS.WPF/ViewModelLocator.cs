using GNW.ILS.API;
using GNW.ILS.WPF.Services;
using GNW.ILS.WPF.ViewModels;

namespace GNW.ILS.WPF
{
    public class ViewModelLocator
    {
        //private static IDialogService dialogService = new DialogService();
        private static IUserDataService userDataService = new UserDataService(new UserAPI(null));

        private static MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();
        private static LoggingViewModel _loggingViewModel = new LoggingViewModel(userDataService);
        private static DockingViewModel _dockingViewModel = new DockingViewModel();
        private static ClientViewModel _clientViewModel = new ClientViewModel();
        private static MainViewModel _mainViewModel = new MainViewModel();
        private static ClientListViewModel _clientListViewModel = new ClientListViewModel();

        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return _mainWindowViewModel;
            }
        }

        public static LoggingViewModel LoggingViewModel
        {
            get
            {
                return _loggingViewModel;
            }
        }

        public static DockingViewModel DockingViewModel
        {
            get
            {
                return _dockingViewModel;
            }
        }

        public static ClientViewModel ClientViewModel
        {
            get
            {
                return _clientViewModel;
            }
        }

        public static MainViewModel MainViewModel
        {
            get
            {
                return _mainViewModel;
            }
        }

        public static ClientListViewModel ClientListViewModel
        {
            get
            {
                return _clientListViewModel;
            }
        }
    }
}
