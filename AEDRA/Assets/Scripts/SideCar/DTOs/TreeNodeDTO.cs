using System.Collections.Generic;

namespace SideCar.DTOs
{
    public class TreeNodeDTO: ElementDTO
    {
        public int ParentId{get; set;}
        public List<int> Children{get;set;}
        public TreeNodeDTO(int id, object value, List<int> children) : base(id, value)
        {
            this.Children = children;
            base.Name="Node";
        }
    }
}