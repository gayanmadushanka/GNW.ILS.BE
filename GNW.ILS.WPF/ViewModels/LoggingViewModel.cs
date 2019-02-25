using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GNW.ILS.WPF.Helpers;
using GNW.ILS.WPF.Messages;
using GNW.ILS.WPF.Models;
using GNW.ILS.WPF.Services;
using GNW.ILS.WPF.Utility;
using GNW.ILS.WPF.Views;
using JoeCoffeeStore.StockManagement.App.Utility;

namespace GNW.ILS.WPF.ViewModels
{
    public class LoggingViewModel : ViewModelBase
    {
        private int _errorCode;

        public ICommand LogInCommand { get; set; }

        private IUserDataService _userDataService;

        #region Properties

        private UserModel _userModel = new UserModel();
        public UserModel UserModel
        {
            get { return _userModel; }
            set
            {
                _userModel = value;
                NotifyPropertyChanged("UserModel");
            }
        }

        #endregion

        public LoggingViewModel(IUserDataService userDataService)
        {
            _userDataService = userDataService;
            LogInCommand = new DelegateCommand(ExecuteLogInCommand);
        }

        private void ExecuteLogInCommand(object obj)
        {
            Common.LoadProgressBar();
            if (_userDataService.CheckUserAuthentication(UserModel.UserName, UserModel.Password))
            {
                RunBackgroundWorker();
            }
            else
            {
                //Common.FlowView.Pop();
                //Common.AddView(Common.FlowView.Peek());
            }
        }

        private void RunBackgroundWorker()
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += worker_DoWork;
            backgroundWorker.RunWorkerCompleted += worker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _errorCode = 0;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Common.FlowView.Pop();
            switch (_errorCode)
            {
                case 0:
                    Common.AddView(new MainView());
                    break;
            }
            //Common.BtnLogout.Visibility = Visibility.Visible;
            Messenger.Default.Send(new LogedInMessage());
        }

        private bool ValidateForm()
        {
            return true;
        }
    }
}
