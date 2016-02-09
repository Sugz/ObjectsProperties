using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsProperties.Src.Helpers;

namespace ObjectsProperties.Src.Models
{
    public static class Scene
    {
        /// <summary>
        /// Get the Root node
        /// </summary>
        public static Node Root
        {
            get { return new Node(MaxUtils.Interface.RootNode); }

        }

        /// <summary>
        /// Get the nodes without parent
        /// </summary>
        public static IEnumerable<Node> FirstNodes
        {
            get { return Root.Children; }

        }

        /// <summary>
        /// Get all the nodes
        /// </summary>
        public static IEnumerable<Node> AllNodes
        {
            get { return Root.ChildrenTree; }
        }



    }
}
