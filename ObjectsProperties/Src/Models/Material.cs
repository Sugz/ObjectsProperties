using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;

namespace ObjectsProperties.Src.Models
{
    public class Material
    {

        #region Properties

        /// <summary>
        /// The wrapped IMtl
        /// </summary>
        public IMtl _Mtl { get; private set; }

        /// <summary>
        /// Get and set material's name
        /// </summary>
        public String Name
        {
            get { return _Mtl.Name; }
            set { _Mtl.Name = value; }
        }


        #endregion



        #region Constructor


        public Material(IMtl mtl)
        {
            _Mtl = mtl;
        }


        #endregion


    }
}
