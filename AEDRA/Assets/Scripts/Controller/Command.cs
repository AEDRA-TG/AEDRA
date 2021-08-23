using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;

namespace Controller
{
    /// <summary>
    /// Interface for defining operations of a generic command
    /// </summary>
    public abstract class Command
    {
        public static event Action<OperationEnum> OperationCompleted;
        /// <summary>
        /// Method to execute the command
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Method to Notify observer that the specified operation has completed execution
        /// </summary>
        /// <param name="operation">Enum indicating the operation that has finished</param>
        public void Notify(OperationEnum operation){
            OperationCompleted?.Invoke(operation);
        }
    }
}