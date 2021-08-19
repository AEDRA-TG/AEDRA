using Utils.Enums;

namespace SideCar.DTOs
{
    public class DataStructureElementDTO
    {
        public int Id {get; set;}
        //Todo define passing generic values
        public object Value {get; set;}

        public AnimationEnum Operation {get; set;}
        public DataStructureElementDTO(int id, object value){
            Id = id;
            Value = value;
        }
    }
}