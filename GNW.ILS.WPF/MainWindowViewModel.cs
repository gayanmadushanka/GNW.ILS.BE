using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GNW.ILS.WPF.Helpers;
using GNW.ILS.WPF.Messages;
using GNW.ILS.WPF.Utility;
using GNW.ILS.WPF.ViewModels;
using GNW.ILS.WPF.Views;
using JoeCoffeeStore.StockManagement.App.Utility;

namespace GNW.ILS.WPF
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Visibility _btnLogoutVisibility = Visibility.Collapsed;
        public Visibility BtnLogoutVisibility
        {
            get
            {
                return _btnLogoutVisibility;
            }
            set
            {
                _btnLogoutVisibility = value;
                NotifyPropertyChanged("BtnLogoutVisibility");
            }
        }

        public ICommand LogOutCommand { get; set; }

        public MainWindowViewModel()
        {
            LogOutCommand = new DelegateCommand(ExecuteLogOutCommand);
            Messenger.Default.Register<LogedInMessage>(this, LogedInMessageReceived);
        }

        private void LogedInMessageReceived(object obj)
        {
            BtnLogoutVisibility = Visibility.Visible;  
        }

        private void ExecuteLogOutCommand(object obj)
        {
            //Common.FlowView.Pop();
            Common.AddView(new LoggingView());
            BtnLogoutVisibility = Visibility.Collapsed;
        }
    }
}
