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


        /// <summary>
        /// Select nodes
        /// </summary>
        /// <param name="nodes">the list of nodes to select</param>
        public void Select(IEnumerable<Node> nodes)
        {
            _nodes = nodes;
            _selectType = SelectType.Select;
            this.Execute();
        }

        /// <summary>
        /// Add nodes to selection
        /// </summary>
        /// <param name="nodes">the list of nodes to select</param>
        public void AddToSelection(IEnumerable<Node> nodes)
        {
            _nodes = nodes;
            _selectType = SelectType.Add;
            this.Execute();
        }

        /// <summary>
        /// Deselect nodes
        /// </summary>
        /// <param name="nodes"></param>
        public void Deselect(IEnumerable<Node> nodes)
        {
            _nodes = nodes;
            _selectType = SelectType.Deselect;
            this.Execute();
        }

    }
}
