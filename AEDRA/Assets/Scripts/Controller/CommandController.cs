using System.Collections.Generic;
using Utils.Enums;
using UnityEngine;
using Repository;
using Model.Common;

namespace Controller
{
    /// <summary>
    /// Class to manage the different commands used in the application
    /// </summary>
    public class CommandController
    {
        /// <summary>
        /// Property used to store the command controller instance
        /// </summary>
        private static CommandController _commandController;
        public IDataStructureRepository Repository {get; set;}

        /// <summary>
        /// Singleton Method
        /// </summary>
        /// <returns>Unique instance of CommandController</returns>
        public static CommandController GetInstance(){
            if(_commandController == null){
                _commandController = new CommandController();
            }
            return _commandController;
        }
        /// <summary>
        /// Method to execute any command
        /// </summary>
        /// <param name="command">Command to executed</param>
        public void Invoke(Command command){
            command.Execute();
        }
    }
}