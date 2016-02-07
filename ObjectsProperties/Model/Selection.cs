using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;
using ObjectsProperties.Src;

namespace ObjectsProperties.Model
{
    public class Selection : INotifyPropertyChanged
    {

        #region Fields


        private GlobalDelegates.Delegate5 SelectionSetChanged;                                      // Define the SelectionSetChanged notification callback
        private List<string> names = new List<string>();


        #endregion



        #region Properties


        public List<IINode> Nodes { get; private set; }
        public int Count { get; private set; }
        public List<string> Names { get { return names; } }
        public List<IMtl> Materials { get; private set; }


        #endregion



        #region Constructor


        public Selection()
        {
            // Initialize Lists
            Nodes = new List<IINode>();
            Materials = new List<IMtl>();

            // Register the notification callbacks
            SelectionSetChanged = new GlobalDelegates.Delegate5(SelectionSetChangedCallback);
            MaxUtils.Global.RegisterNotification(SelectionSetChanged, null, SystemNotificationCode.SelectionsetChanged);

        }



        #endregion



        #region Methods


        #region Private

        /// <summary>
        /// Method call on the SelectionSetChanged Callback
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="info"></param>
        private void SelectionSetChangedCallback(IntPtr obj, IntPtr info)
        {
            // Get the selection
            GetSelection();
        }


        /// <summary>
        /// Set the lists properties
        /// </summary>
        private void SetLists()
        {
            names.Clear();
            Materials.Clear();

            foreach (IINode node in Nodes)
            {
                names.Add(node.Name);
                Materials.Add(node.Mtl);
            }
        }


        #endregion


        #region Public


        /// <summary>
        /// Set the lists
        /// </summary>
        public void GetSelection()
        {
            // Reset the Nodes list and set it given the new selection
            Count = MaxUtils.Interface.SelNodeCount;
            Nodes.Clear();
            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    Nodes.Add(MaxUtils.Interface.GetSelNode(i));
                }
            }

            // Set the lists and fire the event
            SetLists();
            OnPropertyChanged("Nodes");
        }


        /// <summary>
        /// Rename selected node when selection only contain one object
        /// </summary>
        /// <param name="name">The new name for the node</param>
        public void RenameNode(string name)
        {
            if (Count == 1)
            {
                Nodes[0].Name = name;
            }
        }


        #endregion


        #endregion



        #region Events


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion

    }
}
