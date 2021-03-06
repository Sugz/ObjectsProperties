﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using Autodesk.Max;
using SugzTools.Max.Commands;
using SugzTools.Max.Helpers;
using SugzTools.Max.Models;
using SugzTools.Src;

namespace ObjectsProperties.ViewModels
{
    public class ObjectsPropertiesVM : INotifyPropertyChanged
    {
        // Fields
        #region Fields


        private ICommand _selectByProperties;
        //private bool _canSelectFirstNodes;



        #endregion // End Fields



        // Properties
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
                Selection.Nodes[0].Name = nameTxt;
            }
        }

        public string MaterialTxt { get; set; }



        /// <summary>
        /// ***** For Test only **********
        /// </summary>
        public string CheckBtnTxt { get; private set; }



        public ICommand SelectByProperties
        {
            get { return _selectByProperties ?? (_selectByProperties = new RelayCommand(SelectByPropertiesAction)); }
        }




        #endregion // End Properties



        // Constructor
        #region Constructor


        public ObjectsPropertiesVM()
        {
            Selection = new Selection();
            Selection.PropertyChanged += Selection_SelectionSetChanged;

            //_canSelectFirstNodes = true;
        }


        #endregion // End Constructor



        // Methods
        #region Methods


        // Private
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
                    nameTxt = Selection.Nodes[0].Name;
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
                MaterialTxt = (Selection.Nodes[0].Mtl != null) ? Selection.Nodes[0].Mtl.Name : "Unassign";
                for (int i = 1; i < count; i++)
                {
                    if (MaterialTxt != ((Selection.Nodes[i].Mtl != null) ? Selection.Nodes[i].Mtl.Name : "Unassign"))
                    {
                        MaterialTxt = "Multiple";
                        break;
                    }
                }
            }
            
            // Fire the event
            OnPropertyChanged("MaterialTxt");
        }


        #endregion // End Private



        // Public
        #region Public

        /// <summary>
        /// Select first nodes
        /// </summary>
        public void SelectByPropertiesAction(object button)
        {
            Button clickedbutton = button as Button;
            if (clickedbutton != null)
            {
                switch(clickedbutton.Tag.ToString())
                {
                    case "roots":
                        SelectCommand select = new SelectCommand(Scene.FirstNodes, SelectType.Select);
                        break;
                    case "test":
                        new SelectCommand(Scene.FirstNodes, SelectType.Deselect);
                        break;

                }
            }
        }


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
