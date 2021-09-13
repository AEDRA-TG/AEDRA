namespace Controller
{
    public class CleanStructureCommand : Command
    {
        public override void Execute()
        {
            CommandController.GetInstance().Repository.Clean();
        }
    }
}