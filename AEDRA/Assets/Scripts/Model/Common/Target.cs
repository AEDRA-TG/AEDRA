using System.Collections;
using System.Collections.Generic;

namespace Model.Common
{
    public class Target
    {
        public string Name { get; set; }
        public string ARMarker { get; set; }
        public string Description { get; set; }

        public List<Target> Faces { get; set; }

        public Target(){}

        public Target(string name, string arMarker, string description, List<Target> faces){
            this.Name = name;
            this.ARMarker = arMarker;
            this.Description = description;
            this.Faces = faces;
        }
    }
}