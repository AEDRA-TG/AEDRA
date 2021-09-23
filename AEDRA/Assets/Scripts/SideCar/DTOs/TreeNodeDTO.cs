using System.Collections.Generic;

namespace SideCar.DTOs
{
    /// <summary>
    /// Class that contains a Tree Node information
    /// </summary>
    public class TreeNodeDTO: ElementDTO
    {
        /// <summary>
        /// Parent id of the node
        /// </summary>
        /// <value>Null if node is the tree root</value>
        public int ParentId{get; set;}

        /// <summary>
        /// List of the node childrens
        /// </summary>
        public List<int> Children{get;set;}

        public TreeNodeDTO(int id, object value, List<int> children) : base(id, value)
        {
            this.Children = children;
            base.Name="Node";
        }
    }
}