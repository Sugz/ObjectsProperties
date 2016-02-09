using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;
using ObjectsProperties.Src.Commands;
using ObjectsProperties.Src.Helpers;

namespace ObjectsProperties.Src.Models
{
    public class Selection : INotifyPropertyChanged
    {

        #region Fields


        private GlobalDelegates.Delegate5 SelectionSetChanged;                                      // Define the SelectionSetChanged notification callback


        #endregion



        #region Properties


        public List<Node> Nodes { get; private set; }
        public int Count { get { return Nodes.Count; } }


        #endregion



        #region Constructor


        public Selection()
        {
            // Initialize Nodes list
            Nodes = new List<Node>();

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



        #endregion


        #region Public


        /// <summary>
        /// Set the lists
        /// </summary>
        public void GetSelection()
        {
            // Reset the Nodes list and set it given the new selection
            Nodes.Clear();
            for (int i = 0; i < MaxUtils.Interface.SelNodeCount; i++)
            {
                Nodes.Add(new Node(MaxUtils.Interface.GetSelNode(i)));
            }

            // Fire the event
            OnPropertyChanged("Nodes");
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
