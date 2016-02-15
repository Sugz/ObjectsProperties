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

    public class SelectCommand : RestoreCommand
    {

        private IEnumerable<Node> _nodes;
        private SelectType _selectType;
        private string _description;

        private List<Node> _oldNodes = new List<Node>();

        public override string Description { get { return _description; } }


        public SelectCommand(IEnumerable<Node> nodes, SelectType selectType)
        {
            _nodes = nodes;
            _selectType = selectType;

            switch (_selectType)
            {
                case SelectType.Select:
                    _description = "Select Command";
                    break;
                case SelectType.Add:
                    _description = "Add to Selection Command";
                    break;
                case SelectType.Deselect:
                    _description = "Deselect Command";
                    break;
            }

            Selection sel = new Selection();
            foreach (Node node in sel.Nodes)
                _oldNodes.Add(node);

            Execute();
        }


        /// <summary>
        /// Do the action corresponding to the SelectType
        /// </summary>
        public override void Redo()
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

        public override void Restore(bool isUndo)
        {
            MaxUtils.Interface.ClearNodeSelection(false);
            foreach (Node node in _oldNodes)
                node.IsSelected = true;
        }

    }
}

