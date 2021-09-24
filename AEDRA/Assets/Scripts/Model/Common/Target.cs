namespace Model.Common
{
    public class Target
    {
        public string Name { get; set; }
        public string ARMarker { get; set; }
        public string Description { get; set; }

        public Target(){}

        public Target(string name, string arMarker, string description){
            this.Name = name;
            this.ARMarker = arMarker;
            this.Description = description;
        }
    }
}