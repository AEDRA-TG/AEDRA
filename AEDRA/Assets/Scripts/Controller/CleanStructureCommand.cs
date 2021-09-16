namespace Controller
{
    /// <summary>
    /// Class to manage the clean structure command
    /// </summary>
    public class CleanStructureCommand : Command
    {
        public override void Execute()
        {
            CommandController.GetInstance().Repository.Clean();
        }
    }
}