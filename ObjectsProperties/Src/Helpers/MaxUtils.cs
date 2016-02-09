using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;

namespace ObjectsProperties.Src.Helpers
{
    public static class MaxUtils
    {

        public static IGlobal Global { get { return GlobalInterface.Instance; } }
        public static IInterface14 Interface { get { return Global.COREInterface14; } }
        public static IHold Hold { get { return Global.TheHold; } }

    }
}
