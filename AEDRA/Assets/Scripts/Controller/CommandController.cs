using Repository;

namespace Controller
{
    /// <summary>
    /// Class to manage the different commands used in the application
    /// </summary>
    public class CommandController
    {
        /// <summary>
        /// Field name used to store the command controller instance
        /// </summary>
        private static CommandController _commandController;

        /// <summary>
        /// Property name for the data structure repository
        /// </summary>
        public DataStructureRepository Repository {get; set;}

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