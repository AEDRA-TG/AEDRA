
namespace Controller
{
    /// <summary>
    /// Command to persist the state of a datastructure
    /// </summary>
    public class SaveCommand : Command
    {
        public override void Execute()
        {
            CommandController.GetInstance().Repository.Save();
        }
    }
}