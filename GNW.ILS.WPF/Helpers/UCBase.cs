using System.Windows.Controls;

namespace GNW.ILS.WPF.Helpers
{

    public class UCBase : UserControl
    {
        public static Grid GdContent;

        public void AddViewToGrid(UserControl userControl)
        {
            GdContent.Children.Clear();
            GdContent.Children.Add(userControl);
        }
    }
}
