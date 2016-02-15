using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using ObjectsProperties.Src.Models;
using ObjectsProperties.ViewModels.Helper;
using System.Collections.ObjectModel;

namespace ObjectsProperties.ViewModels
{
    public class IsolateSelectionVM : INotifyPropertyChanged
    {

        // Fields
        #region Fields

        private List<List<Node>> Nodes = new List<List<Node>>();
        private Selection Selection = new Selection();

        private ICommand _setIsolation;

        #endregion // End Fields



        // Properties
        #region Properties

        public ObservableCollection<String> Level { get; set; }
        public int SelectedIndex { get; set; }

        public ICommand SetIsolation
        {
            get { return _setIsolation ?? (_setIsolation = new RelayCommand(SetIsolationsAction)); }
        }

        


        #endregion // End Properties



        // Constructor
        #region Constructor

        public IsolateSelectionVM()
        {
            Level = new ObservableCollection<String>();
            //SelectedIndex = -1;
        }



        #endregion // End Constructor



        // Methods
        #region Methods


        // Private
        #region Private


        private void SetIsolationsAction(object obj)
        {
            // Store the current selection in the Nodes list corresponding to the isolation level
            Nodes.Add((Selection.Nodes).ToList());

            // Execute the isolate selection action item
            ActionItem isolate = ActionManager.GetActionItem(0, 197);
            isolate.Execute();

            // Add an isolation level in the Level property and fire the event to fill the dropdownlist
            Level.Add("Isolate Level " + (Nodes.Count).ToString());
            OnPropertyChanged("Level");
        }


        #endregion // End Private



        // Public
        #region Public




        #endregion // End Public


        #endregion // End Methods



        // Events
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion // End Events



    }
}
 