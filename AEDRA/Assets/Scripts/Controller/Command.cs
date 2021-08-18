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

        public void Notify(OperationEnum operation){
            OperationCompleted?.Invoke(operation);
        }
    }
}