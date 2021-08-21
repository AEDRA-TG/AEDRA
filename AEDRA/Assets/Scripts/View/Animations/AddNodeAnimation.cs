using SideCar.DTOs;
using UnityEngine;
using View.GUI;

namespace View.Animations
{
    public class AddNodeAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (DataStructureElementDTO dto in projection.DTOs)
            {
                System.Random rand = new System.Random();
                //TODO: review how to calculate coordinates
                Vector3 coordinates = new Vector3(rand.Next(20),rand.Next(20), rand.Next(20));
                //TODO: fix Id concatenation
                string id = "Node_" + dto.Id;
                ProjectedObject obj = GameObject.Find(id).GetComponentInChildren<ProjectedObject>();
                obj.Move(coordinates);
            }
        }
    }
}