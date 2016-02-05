using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;

namespace ObjectsProperties.Src
{
    public static class MaxUtils
    {

        public static IGlobal Global
        {
            get { return GlobalInterface.Instance; }
        }


        public static IInterface14 Interface
        {
            get { return Global.COREInterface14; }
        }


    }
}
