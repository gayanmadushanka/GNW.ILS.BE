using System.Collections.Generic;
using System.Windows.Controls;
using GNW.ILS.WPF.Views.Shared;

namespace GNW.ILS.WPF.Helpers
{
   public class Common
    {
       //public static Stack<Control> FlowView = new Stack<Control>();
       public static Grid GdBodyContent;
       //public static Button BtnLogout;
       public static Grid GdContent { get; set; }

       //public static Control GoBack()
       //{
       //    FlowView.Pop();
       //    Control control = FlowView.Peek();
       //    AddView(control);
       //    return control;
       //}

       public static void AddView(Control control)
       {
           GdBodyContent.Children.Clear();
           GdBodyContent.Children.Add(control);
       }

       public static void LoadProgressBar()
       {
           LoadingAnimation operation = new LoadingAnimation();
           AddView(operation);
       }

       public static void AddViewToGrid(UserControl userControl)
       {
           GdContent.Children.Clear();
           GdContent.Children.Add(userControl);
       }

       public static string FirstName;
       public static string LastName;
       public static byte[] Image;
    }
}
