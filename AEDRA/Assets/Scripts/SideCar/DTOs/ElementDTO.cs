using Utils.Enums;

namespace SideCar.DTOs
{
    public class ElementDTO
    {
        public int Id {get; set;}
        //Todo define passing generic values
        public object Value {get; set;}
        public string Name {get; set;}

        public AnimationEnum Operation {get; set;}
        public ElementDTO(int id, object value){
            Id = id;
            Value = value;
        }

        public string GetUnityId(){
            return Name + "_" + Id;
        }
    }
}