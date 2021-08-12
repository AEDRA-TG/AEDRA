using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    /// <summary>
    /// Interface for defining operations of a generic command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Method to execute the command
        /// </summary>
        public void Execute();
    }
}