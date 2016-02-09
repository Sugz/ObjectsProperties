using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiViewModels.Actions;

namespace ObjectsProperties.Src
{
    /// <summary>
    /// An adapter for the ICuiDockableContent interface that provides default implementations
    ///             of many of the interface methods.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// This is an adapter class.  A client only need to satisfy the ICuiDockableContent interface
    ///             for their class to be loaded by the managed assembly loading process.  However, this
    ///             class is easier to use.
    /// 
    /// </remarks>
    public class CuiLoader : ICuiDockableContent, ICuiAction
    {
        /// <summary>
        /// The name that the CUIFrame should assume.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// This property should be localizable.
        /// 
        /// </remarks>
        public abstract string WindowTitle { get; }

        /// <summary>
        /// The Type of the user control that is created by this action.
        /// 
        /// </summary>
        public abstract Type ContentType { get; }

        /// <summary>
        /// Return true if moving the CUIFrame should Invalidate the user control and
        ///             force a repaint.
        /// 
        /// </summary>
        public virtual bool InvalidateOnMoved
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Return true if, when the CUIFrame dialog is closed, it should call DestroyWindow()
        ///             on itself.  Alternatively, if false is returned here, the window will simply be
        ///             closed, but not destroyed.  This would be useful if the content is expensive to
        ///             create.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// The default implementation does destroy the content on close.
        /// 
        /// </remarks>
        public virtual bool DestroyOnClose { get; set; }

        /// <summary>
        /// The dock modes that this control supports.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// By default, this property is implemented to only return the Top docking
        ///             position as a possible dock mode.
        /// 
        /// </remarks>
        public DockStates.Dock DockingModes { get { return DockStates.Dock.Left | DockStates.Dock.Floating; } }

        /// <summary>
        /// By default, control docks maximized.
        /// 
        /// </summary>
        public virtual bool DocksMaximized
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// By default, the control is not considered a main toolbar.
        /// 
        /// </summary>
        public virtual bool IsMainContent
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The name of the action - to be used when browsing a list
        ///             of actions.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Required for ICuiAction.
        /// 
        /// </remarks>
        /// <seealso cref="T:UiViewModels.Actions.ICuiAction"/>
        public abstract string ActionText { get; }

        /// <summary>
        /// The name of the category to which this action should belong.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Required for ICuiAction.
        /// 
        /// </remarks>
        /// <seealso cref="T:UiViewModels.Actions.ICuiAction"/>
        public abstract string Category { get; }

        /// <summary>
        /// This is internal text that is not used in the user interface anywhere,
        ///             but is used to uniquely identify the action.  This text should be
        ///             identical across all localized versions of the product.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Default implementation is to return ActionText, but should definitely be overriden for
        ///             any production-level code that requires localization.
        /// 
        /// </remarks>
        /// <seealso cref="T:UiViewModels.Actions.ICuiAction"/>
        public virtual string InternalActionText
        {
            get
            {
                return this.ActionText;
            }
        }

        /// <summary>
        /// This is internal text that is not used in the user interface anywhere,
        ///             but is used to uniquely identify the action category.  This text should be
        ///             identical across all localized versions of the product.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Default implementation is to return Category, but should definitely be overriden for
        ///             any production-level code that requires localization.
        /// 
        /// </remarks>
        /// <seealso cref="T:UiViewModels.Actions.ICuiAction"/>
        public virtual string InternalCategory
        {
            get
            {
                return this.Category;
            }
        }

        /// <summary>
        /// The text that will be used if the action is instantiated in a toolbar button.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// By default implementation is to forward ActionText as the result.
        /// 
        /// </remarks>
        public virtual string ButtonText
        {
            get
            {
                return this.ActionText;
            }
        }

        /// <summary>
        /// The text that will be used if the action is instantiated in the application menu or
        ///             a quad-menu.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// By default implementation is to forward ActionText as the result.
        /// 
        /// </remarks>
        public virtual string MenuText
        {
            get
            {
                return this.ActionText;
            }
        }

        /// <summary>
        /// Marks whether this action should appear in a menu.  This condition is evaluated
        ///             whenever a menu is shown - meaning the result can be dynamic.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// By default implementation is to return true.
        /// 
        /// </remarks>
        public virtual bool IsVisible
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Marks when this action should be available for use.  This condition is evaluated
        ///             whenever a menu is shown - meaning the result can be dynamic.  If False, an item
        ///             will appear "grayed out".
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// By default implementation is to return true.
        /// 
        /// </remarks>
        public virtual bool IsEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Implement this method if the action is "checked" (which means that the UI will show
        ///             the button as pressed, or the menu item as checked.)
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// By default implementation is to return false.
        /// 
        /// </remarks>
        public virtual bool IsChecked
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Implement this method if your component does not capture keyboard focus when it activates.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Default implementation is to return true.
        /// </remarks>
        public virtual bool NeedsKeyboardFocus
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets access to the tooltip key which is assigned to the action
        ///             The key is used to connect the action and its rich tooltip which is prepared by
        ///             Doc team.
        /// 
        /// </summary>
        public string TooltipKey
        {
            get
            {
                return "Invalid Tooltip Key!";
            }
        }

        /// <summary>
        /// This should be raised when this component is asked to reset its configuration
        ///             to factory defaults.
        /// 
        /// </summary>
        public event EventHandler<EventArgs> ResettingConfiguration;

        /// <summary>
        /// This should be raised when this component is currently saving out its current state.
        /// 
        /// </summary>
        public event EventHandler<CuiDockableContentConfigEventArgs> SavingConfiguration;

        /// <summary>
        /// This should be raised when this component is currently loading in a persisted state.
        /// 
        /// </summary>
        public event EventHandler<CuiDockableContentConfigEventArgs> LoadingConfiguration;

        /// <summary>
        /// Constructor - initializes the DestroyOnClose property to true.
        /// 
        /// </summary>
        public CuiDockableContentAdapter()
        {
            this.DestroyOnClose = true;
        }

        /// <summary>
        /// This method is called by the managed assembly loading process process
        ///             when it is ready to create and show the managed user control.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the Control to create and place as the root object
        ///             in a CUIFrame.
        /// 
        /// </returns>
        public abstract object CreateDockableContent();

        /// <summary>
        /// This is a callback function that 3ds Max calls when the CUI frame is docked
        ///             or floated from the main application frame.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// By default, this fucntion does nothing.  Implement this method to notify content of
        ///             docking changes.
        /// 
        /// </remarks>
        /// <param name="dockableContent">An instance of a Control returned by CreateDockableContent().</param><param name="dockMode">The new dock state of the CUIFrame.</param><seealso cref="M:UiViewModels.Actions.CuiDockableContentAdapter.CreateDockableContent"/>
        public virtual void SetContentDockMode(object dockableContent, DockStates.Dock dockMode)
        {
        }

        /// <summary>
        /// Raises the ResettingConfiguration event.
        /// 
        /// </summary>
        public void RaiseResettingConfiguration()
        {
            this.OnResettingConfiguration(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the ResettingConfiguration event with the passed in parameters.
        /// 
        /// </summary>
        /// <param name="args">normally EventArgs.Empty</param>
        protected virtual void OnResettingConfiguration(EventArgs args)
        {
            DelegateCaller.Call((Delegate)this.ResettingConfiguration, (object)this, (object)args);
        }

        /// <summary>
        /// Raises the SavingConfiguration event with the passed in file name.
        /// 
        /// </summary>
        /// <param name="aFilename">The full path of the file where the configuration is being saved.</param>
        public void RaiseSavingConfiguration(string aFilename)
        {
            this.OnSavingConfiguration(new CuiDockableContentConfigEventArgs(aFilename));
        }

        /// <summary>
        /// Raises the SavingConfiguration event with the passed in parameters.
        /// 
        /// </summary>
        /// <param name="args">EventArgs that store the target filename</param>
        protected virtual void OnSavingConfiguration(CuiDockableContentConfigEventArgs args)
        {
            DelegateCaller.Call((Delegate)this.SavingConfiguration, (object)this, (object)args);
        }

        /// <summary>
        /// Raises the LoadingConfiguration event with the passed in file name.
        /// 
        /// </summary>
        /// <param name="aFilename">The full path of the file where the configuration is being loaded from.</param>
        public void RaiseLoadingConfiguration(string aFilename)
        {
            this.OnLoadingConfiguration(new CuiDockableContentConfigEventArgs(aFilename));
        }

        /// <summary>
        /// Raises the LoadingConfiguration event with the passed in parameters.
        /// 
        /// </summary>
        /// <param name="args">EventArgs that store the target filename</param>
        protected virtual void OnLoadingConfiguration(CuiDockableContentConfigEventArgs args)
        {
            DelegateCaller.Call((Delegate)this.LoadingConfiguration, (object)this, (object)args);
        }
    }
}
