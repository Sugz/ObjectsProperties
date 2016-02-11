using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiViewModels.Actions;
using ObjectsProperties.Views;

namespace ObjectsProperties.Src
{
    public class Loader : CuiDockableContentAdapter
    {

        #region Fields

        // Create an instance of the view to be able to modify it in this class
        private ObjectsPropertiesView objectsPropertiesView = new ObjectsPropertiesView();


        #endregion


        #region Properties

        public override string ActionText { get { return "Objects Properties"; } }
        public override string Category { get { return "SugzTools"; } }
        public override string WindowTitle { get { return "Objects Properties"; } }
        public override Type ContentType { get { return typeof(ObjectsPropertiesView); } }
        public override DockStates.Dock DockingModes { get { return DockStates.Dock.Left | DockStates.Dock.Floating; } }
        public override bool IsMainContent { get { return true; } }

        #endregion


        #region Methods

        public override object CreateDockableContent() { return objectsPropertiesView; }


        // Modify the view based on the dockMode
        public override void SetContentDockMode(object dockableContent, DockStates.Dock dockMode)
        {
            base.SetContentDockMode(dockableContent, dockMode);
            objectsPropertiesView.SetResizeBorders(dockMode);
        }

        #endregion


    }
}
