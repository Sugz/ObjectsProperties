using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;

namespace ObjectsProperties.Model
{
    public class Node
    {


        /// <summary>
        /// 
        /// </summary>
        public IINode _Node { get; private set; }

        
        /// <summary>
        /// Get node's name
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// Get node's children
        /// TODO: implement a setter to set Node as child of another Node
        /// </summary>
        public IEnumerable<Node> Children
        {
            get
            {
                for (int i = 0; i < _Node.NumberOfChildren; i++)
                    if (_Node.GetChildNode(i) != null)
                        yield return new Node(_Node.GetChildNode(i));
            }
        }


        /// <summary>
        /// Get node's children tree
        /// </summary>
        public IEnumerable<Node> ChildrenTree
        {
            get
            {
                foreach (Node child in Children)
                {
                    foreach (Node nextChild in child.ChildrenTree)
                        yield return nextChild;
                    yield return child;
                }
            }
        }


        /// <summary>
        /// Get node's parent
        /// TODO : implement the setter (have to create a method that implement "void AttachChild(IINode node, bool keepTM)")
        /// </summary>
        public Node Parent
        {
            get
            {
                //if (_Node.ParentNode != Scene.Root)
                //    return new Node(_Node.ParentNode);
                //else
                //    return Scene.Root;
                return (_Node.ParentNode != Scene.Root) ? new Node(_Node.ParentNode) : Scene.Root;
            }

            set
            {
                if (value != null)
                    value.AttachChild(this);
                else
                    Scene.Root.AttachChild(this);
            }
        }


        /// <summary>
        /// Get node's parent tree
        /// </summary>
        /// <param name="node"></param>
        public IEnumerable<Node> ParentTree
        {
            get
            {
                yield return Parent;
                while (Parent.Parent != Scene.Root)
                {
                    Parent = Parent.Parent;
                    yield return Parent;
                }

            }
        }



        #region Constructor


        public Node(IINode node)
        {
            _Node = node;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Makes the specified node a child of this node.
        /// </summary>
        /// <param name="node">The node to attach.</param>
        public void AttachChild(Node node)
        {
            AttachChild(node, false);
        }

        /// <summary>
        /// Makes the specified node a child of this node.
        /// </summary>
        /// <param name="node">The node to attach.</param>
        /// <param name="keepTM">If nonzero, the world transform matrix of the specified (child) node is unchanged after the attach operation, 
        /// i.e. returns the same matrix both before and after the attach operation. 
        /// Otherwise, the world transform of the specified (child) node is affected by the parent node's transform.</param>
        public void AttachChild(Node node, bool keepTM)
        {
            _Node.AttachChild(node._Node, keepTM);
        }



        #endregion

    }
}
