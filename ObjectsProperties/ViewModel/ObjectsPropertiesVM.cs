using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Autodesk.Max;
using ObjectsProperties.Model;
using ObjectsProperties.Src;


namespace ObjectsProperties.ViewModel
{
    public class ObjectsPropertiesVM : INotifyPropertyChanged
    {

        #region Fields





        #endregion



        #region Properties


        public Selection Selection { get; private set; }
        public bool NameTxtReadOnly { get; private set; }

        private string nameTxt;
        public string NameTxt
        {
            get { return nameTxt; }
            set
            {
                nameTxt = value;
                Selection.RenameNode(nameTxt);
            }
        }

        public string MaterialTxt { get; set; }






        #endregion



        #region Constructor


        public ObjectsPropertiesVM()
        {
            Selection = new Selection();
            Selection.PropertyChanged += Selection_SelectionSetChanged;
            Selection.GetSelection();
        }


        #endregion



        #region Methods


        #region Private


        private void Selection_SelectionSetChanged(object sender, PropertyChangedEventArgs e)
        {
            // Set the name text field
            SetNameTxt(Selection.Count);
            SetMaterialTxt(Selection.Count);

        }


        /// <summary>
        /// Set the string for the Name text field
        /// </summary>
        /// <param name="count">The selection count</param>
        private void SetNameTxt(int count)
        {
            switch (count)
            {
                case 0:
                    nameTxt = "No Object Selected";
                    NameTxtReadOnly = true;
                    break;
                case 1:
                    if (Selection.Names.Count > 0) nameTxt = Selection.Names[0];
                    NameTxtReadOnly = false;
                    break;
                default:
                    nameTxt = count + " Objects Selected";
                    NameTxtReadOnly = true;
                    break;
            }

            // Fire the events
            OnPropertyChanged("NameTxt");
            OnPropertyChanged("NameTxtReadOnly");
        }


        /// <summary>
        /// Set the string for the Material text field
        /// </summary>
        /// <param name="count"></param>
        private void SetMaterialTxt(int count)
        {
            // Initialize the string to be empty
            MaterialTxt = "";
            if (count >= 1)
            {
                // Get the first node material name and compare it to the rest of the selection
                MaterialTxt = (Selection.Materials[0] != null) ? Selection.Materials[0].Name : "Unassign";
                for (int i = 1; i < count; i++)
                {
                    string otherMaterial = (Selection.Materials[i] != null) ? Selection.Materials[i].Name : "Unassign";
                    if (otherMaterial != MaterialTxt)
                    {
                        MaterialTxt = "Multiple";
                        break;
                    }
                }
            }

            // Fire the event
            OnPropertyChanged("MaterialTxt");
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
