using System;
using SugzTools.Max.Helpers;
using ObjectsProperties.Views;
using UiViewModels.Actions;

namespace ObjectsProperties
{
    public class CuiLoader : Custom_CuiDockableContentAdapter
    {

        // Fields
        #region Fields


        // Create an instance of the view to be able to modify it in this class
        private ObjectsPropertiesView _View = new ObjectsPropertiesView();


        #endregion // End Fields


        // Properties
        #region Properties


        public override string ActionText { get { return "Objects Properties"; } }
        public override Type ContentType { get { return typeof(ObjectsPropertiesView); } }
        public override DockStates.Dock DockingModes { get { return DockStates.Dock.Left | DockStates.Dock.Floating; } }


        #endregion // End Properties


        // Methods
        #region Methods


        public override object CreateDockableContent() { return _View; }


        // Modify the view based on the dockMode
        public override void SetContentDockMode(object dockableContent, DockStates.Dock dockMode)
        {
            base.SetContentDockMode(dockableContent, dockMode);
            _View.SetResizeBorders(dockMode);
        }


        #endregion // End Methods

    }
}
