using System.Collections;
using System.Collections.Generic;

namespace Controller
{
    public class CommandController
    {
        private static CommandController commandController;
        public static CommandController GetInstance(){
            if(commandController == null){
                commandController = new CommandController();
            }
            return commandController;
        }
        public void Invoke(ICommand command){
            command.Execute();
        }
    }
}