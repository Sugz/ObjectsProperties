using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiViewModels.Actions;
using ObjectsProperties.View;

namespace ObjectsProperties.Src
{
    public class Loader : CuiDockableContentAdapter
    {

        public override string ActionText { get { return "Objects Properties"; } }

        public override string Category { get { return "SugzTools"; } }

        public override string WindowTitle { get { return "Objects Properties"; } }

        public override Type ContentType { get { return typeof(ObjectsPropertiesView); } }

        public override object CreateDockableContent() { return new ObjectsPropertiesView(); }

        public override DockStates.Dock DockingModes { get { return DockStates.Dock.Floating; } }

    }
}
