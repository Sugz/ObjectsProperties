using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;
using ObjectsProperties.Src.Models;
using ObjectsProperties.Src.Helpers;

namespace ObjectsProperties.Src.Commands
{
    /// <summary>
    /// Define the action the SelectCommand have to perform
    /// </summary>
    public enum SelectType
    {
        Select,
        Add,
        Deselect,
    }

    public class SelectCommand : Command
    {

        private IEnumerable<Node> _nodes;
        private SelectType _selectType;


        public override string Description { get { return "Select_Command"; } }


        public SelectCommand(IEnumerable<Node> nodes, SelectType selectType)
        {
            _nodes = nodes;
            _selectType = selectType;
            Execute();
        }


        /// <summary>
        /// Do the action corresponding to the SelectType
        /// </summary>
        public override void Do()
        {
            switch (_selectType)
            {
                case SelectType.Select:
                    MaxUtils.Interface.ClearNodeSelection(false);
                    goto case SelectType.Add;
                case SelectType.Add:
                    foreach (Node node in _nodes)
                        node.IsSelected = true;
                    break;
                case SelectType.Deselect:
                    foreach (Node node in _nodes)
                        if (node != null && node.IsSelected) node.IsSelected = false;
                    break;
            }
        }


    }
}

