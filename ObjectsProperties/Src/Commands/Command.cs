using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Max;
using ObjectsProperties.Src.Helpers;

namespace ObjectsProperties.Src.Commands
{
    /// <summary>
    /// Defines a baseclass for commands that can be registered in the 3dsmax undo system.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// The description of the command.
        /// </summary>
        public abstract String Description { get; }

        /// <summary>
        /// This method should contain the logic to modify the scene when executing the command.
        /// </summary>
        public abstract void Do();

        /// <summary>
        /// Executes the command in an undo context.
        /// </summary>
        public virtual void Execute()
        {
            MaxUtils.Hold.Begin();

            Do();

            MaxUtils.Hold.Accept(this.Description);
        }
    }
}
