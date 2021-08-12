using System.Collections;
using System.Collections.Generic;

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

        /// <summary>
        /// Method to apply the Singleton pattern
        /// </summary>
        /// <returns> Command controller instance </returns>
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
        public void Invoke(ICommand command){
            command.Execute();
        }
    }
}