using System;
using Utils.Enums;

namespace Controller
{
    /// <summary>
    /// Abstract class that contains methods definitions for all commands
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Notifier that indicates to view when an operation has been completed
        /// </summary>
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