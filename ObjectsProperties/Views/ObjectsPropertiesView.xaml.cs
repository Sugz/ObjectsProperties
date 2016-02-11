using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiViewModels.Actions;

namespace ObjectsProperties.Views
{
    /// <summary>
    /// Interaction logic for ObjectsPropertiesView.xaml
    /// </summary>
    public partial class ObjectsPropertiesView : UserControl
    {
        // Fields
        #region Fields


        private Grid leftBorder;
        private Grid rightBorder;
        private Thumb leftResizer;
        private Thumb rightResizer;


        #endregion // End Fields


        // Initialisation
        #region Initialisation


        public ObjectsPropertiesView()
        {
            InitializeComponent();
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            leftBorder = (Grid)GetTemplateChild("LeftBorder");
            rightBorder = (Grid)GetTemplateChild("RightBorder");
            leftResizer = (Thumb)GetTemplateChild("LeftResizer");
            rightResizer = (Thumb)GetTemplateChild("RightResizer");

            leftResizer.DragDelta += Resizer_DragDelta;
            rightResizer.DragDelta += Resizer_DragDelta;
        }


        #endregion // End Initialisation


        // Methods
        #region Methods

        // Private Methods
        #region Private


        private void Resizer_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // Set the new width depending on which thumb trigger the resize and make sure to limit the resize to the MinWidth
            double xAdjust = ((Thumb)sender) == rightResizer ? Width + e.HorizontalChange : Width - e.HorizontalChange;
            Width = (ActualWidth + xAdjust) > MinWidth ? xAdjust : MinWidth;
        }


        #endregion // End Private Methods

        // Public Methods
        #region Public


        public void SetResizeBorders(DockStates.Dock dockMode)
        {
            switch (dockMode)
            {
                case DockStates.Dock.Floating:
                    leftBorder.Visibility = Visibility.Collapsed;
                    rightBorder.Visibility = Visibility.Collapsed;
                    break;
                case DockStates.Dock.Left:
                    leftBorder.Visibility = Visibility.Visible;
                    rightBorder.Visibility = Visibility.Visible;
                    leftResizer.Visibility = Visibility.Collapsed;
                    rightResizer.Visibility = Visibility.Visible;
                    break;
                case DockStates.Dock.Right:
                    leftBorder.Visibility = Visibility.Visible;
                    rightBorder.Visibility = Visibility.Visible;
                    leftResizer.Visibility = Visibility.Visible;
                    rightResizer.Visibility = Visibility.Collapsed;
                    break;
            }
        }


        #endregion // End Public Methods


        #endregion // End Methods
    }
}
