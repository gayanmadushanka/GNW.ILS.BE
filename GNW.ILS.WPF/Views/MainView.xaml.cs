namespace GNW.ILS.WPF.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            GdDockingContent.Children.Clear();
            GdDockingContent.Children.Add(new DockingView());
        }
    }
}
