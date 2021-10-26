using System.Collections.Generic;

namespace SideCar.DTOs
{
    public class Step {
        public int Id {get;set;}
        public string Description {get;set;}
        public List<string> Parameters {get;set;}

        public Step(){

        }

        public Step(int id, string description, List<string> parameters){
            this.Id = id;
            this.Description = description;
            this.Parameters = parameters;
        }
    }
}