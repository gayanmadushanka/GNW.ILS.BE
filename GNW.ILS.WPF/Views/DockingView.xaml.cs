using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GNW.ILS.WPF.Helpers;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace GNW.ILS.WPF.Views
{
    public partial class DockingView : INotifyPropertyChanged
    {
        private enum PaneType
        {
            Green,
            OceanBlue,
            Purple,
            Transparent
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DockingView()
        {
            InitializeComponent();
            Common.GdContent = GdContent;
        }

        #region Docking Panel Operation

        private static bool CompassNeedsToShow(Compass compass)
        {
            return compass.IsLeftIndicatorVisible || compass.IsTopIndicatorVisible || compass.IsRightIndicatorVisible ||
                   compass.IsBottomIndicatorVisible || compass.IsCenterIndicatorVisible;
        }

        private void RadDocking_PreviewShowCompass(object sender, PreviewShowCompassEventArgs e)
        {
            if (e.TargetGroup != null)
            {
                e.Compass.IsCenterIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup,
                    DockPosition.Center);
                e.Compass.IsLeftIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup, DockPosition.Left);
                e.Compass.IsTopIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup, DockPosition.Top);
                e.Compass.IsRightIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup, DockPosition.Right);
                e.Compass.IsBottomIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup,
                    DockPosition.Bottom);
            }
            else
            {
                e.Compass.IsLeftIndicatorVisible = CanDock(e.DraggedSplitContainer, DockPosition.Left);
                e.Compass.IsTopIndicatorVisible = CanDock(e.DraggedSplitContainer, DockPosition.Top);
                e.Compass.IsRightIndicatorVisible = CanDock(e.DraggedSplitContainer, DockPosition.Right);
                e.Compass.IsBottomIndicatorVisible = CanDock(e.DraggedSplitContainer, DockPosition.Bottom);
            }
            e.Canceled = !(CompassNeedsToShow(e.Compass));
        }

        private PaneType GetPaneType(RadPane pane)
        {
            var c = pane.Content as Panel;
            if (c != null)
            {
                if (c.Background != null)
                {
                    if (c.Background.Equals(Resources["GreenBrush"]))
                    {
                        return PaneType.Green;
                    }
                    if (c.Background.Equals(Resources["OceanBlueBrush"]))
                    {
                        return PaneType.OceanBlue;
                    }
                    return PaneType.Purple;
                }
            }
            return PaneType.Purple;
        }

        private bool CanDockIn(RadPane paneToDock, RadPane paneInTargetGroup, DockPosition position)
        {
            PaneType paneToDockType = GetPaneType(paneToDock);
            PaneType paneInTargetGroupType = GetPaneType(paneInTargetGroup);

            switch (paneToDockType)
            {
                case PaneType.Green:
                    switch (paneInTargetGroupType)
                    {

                        case PaneType.Green:
                            return true;
                        case PaneType.OceanBlue:
                            return position != DockPosition.Top && position != DockPosition.Bottom;
                        case PaneType.Purple:
                            return position != DockPosition.Top && position != DockPosition.Bottom;
                    }
                    break;
                case PaneType.OceanBlue:
                    switch (paneInTargetGroupType)
                    {

                        case PaneType.Green:
                            return position != DockPosition.Left && position != DockPosition.Right;
                        case PaneType.OceanBlue:
                            return true;
                        case PaneType.Purple:
                            return position != DockPosition.Left && position != DockPosition.Right;
                    }
                    break;
                case PaneType.Purple:
                    switch (paneInTargetGroupType)
                    {

                        case PaneType.Green:
                            return position != DockPosition.Center;
                        case PaneType.OceanBlue:
                            return position != DockPosition.Center;
                        case PaneType.Purple:
                            return true;
                    }
                    break;
            }
            return false;
        }

        private bool CanDock(RadPane paneToDock, DockPosition position)
        {
            PaneType paneToDockType = GetPaneType(paneToDock);

            switch (paneToDockType)
            {
                case PaneType.Green:
                    return position != DockPosition.Left;
                case PaneType.OceanBlue:
                    return false;
                case PaneType.Purple:
                    return true;
            }
            return false;
        }

        private bool CanDockIn(ISplitItem dragged, ISplitItem target, DockPosition position)
        {
            // If there is a pane that cannot be dropped in any of the targeted panes.
            return !dragged.EnumeratePanes().Any(p => target.EnumeratePanes().Any(p1 => !CanDockIn(p, p1, position)));
        }

        private bool CanDock(ISplitItem dragged, DockPosition position)
        {
            return dragged.EnumeratePanes().All(p => CanDock(p, position));
        }

        #endregion

    }
}
