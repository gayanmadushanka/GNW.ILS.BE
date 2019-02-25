using System.Windows;
using GNW.ILS.WPF.Helpers;
using GNW.ILS.WPF.Views;
using MessageControl;

namespace GNW.ILS.WPF
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Common.GdBodyContent = GdBodyContent;
            //Common.BtnLogout = BtnLogout;
            ContentPanel.MessageControllerStackPanel = MessageControllerStackPanel;
            Common.AddView(new LoggingView());
        }
    }
}
