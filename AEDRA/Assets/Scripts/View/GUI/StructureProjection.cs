using System.Collections.Generic;
using SideCar.DTOs;
using UnityEngine;
using Utils;
using Utils.Enums;
using View.Animations;
using View.GUI.ProjectedObjects;

namespace View.GUI
{
    /// <summary>
    /// Class to update the UI projection of any data structure of the application
    /// </summary>
    public class StructureProjection : MonoBehaviour
    {
        /// <summary>
        /// Name of the structure projection
        /// </summary>
        public StructureEnum Name { get; set; }

        /// <summary>
        /// Type of the structure projection
        /// </summary>
        public string Type { get; set; }
        public List<ElementDTO> DTOs {get; set;}
        public List<ProjectedObject> ProjectedObjects {get; set;}
        private Dictionary<OperationEnum, IAnimationStrategy> _animations;
        public void Awake()
        {
            DTOs = new List<ElementDTO>();
            ProjectedObjects = new List<ProjectedObject>();
            _animations = new Dictionary<OperationEnum, IAnimationStrategy>
            {
                { OperationEnum.AddObject, new AddNodeAnimation() },
                { OperationEnum.DeleteObject, new DeleteNodeAnimation()},
                { OperationEnum.ConnectObjects, new ConnectNodesAnimation()},
                { OperationEnum.TraversalObjects, new TraversalAnimation() },
                { OperationEnum.CreateDataStructure, new CreateDataStructureAnimation() },
                { OperationEnum.UpdateObjects, new UpdateAnimation() }
            };
        }

        /// <summary>
        /// Method to link a DTO with the corresponding projected object
        /// </summary>
        /// <param name="dto"></param>
        public void AddDto(ElementDTO dto)
        {
            if(dto.Operation != AnimationEnum.UpdateAnimation){
                DTOs.Add(dto);
            }
            GameObject obj = GameObject.Find(dto.GetUnityId());
            obj?.GetComponent<ProjectedObject>().SetDTO(dto);
        }

        /// <summary>
        /// Method to invoke an animation
        /// </summary>
        /// <param name="operation"></param>
        public void Animate(OperationEnum operation){
            _animations[operation].Animate();
            DTOs.Clear();
        }

        /// <summary>
        /// Method to instantiate a new GameObject
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ProjectedObject CreateObject(ElementDTO dto){
            Vector3 position = CalculateInitialPosition(dto);
            string prefabPath = Constants.PrefabPath + dto.Name;
            GameObject prefab = Resources.Load(prefabPath) as GameObject;
            prefab = Instantiate(prefab,position,Quaternion.identity,this.transform);
            prefab.name = dto.GetUnityId();
            ProjectedObject createdObject = prefab.GetComponent<ProjectedObject>();
            createdObject.SetDTO(dto);
            ProjectedObjects.Add(createdObject);
            createdObject.PositionObject();
            return createdObject;
        }

        /// <summary>
        /// Method to delete a list of gameObjects
        /// </summary>
        /// <param name="objectsToBeDeleted"></param>
        public void DeleteObject(List<ProjectedObject> objectsToBeDeleted){
            foreach (ProjectedObject dto in objectsToBeDeleted)
            {
                DeleteObject(dto);
            }
        }

        /// <summary>
        /// Method to delete a single GameObject
        /// </summary>
        /// <param name="objectToBeDeleted"></param>
        public void DeleteObject(ProjectedObject objectToBeDeleted){
            this.ProjectedObjects.Remove(objectToBeDeleted);
            Destroy(objectToBeDeleted.gameObject);
        }

        public Vector3 CalculateInitialPosition(ElementDTO dto){
            GameObject structureProjection = GameObject.Find(Constants.ObjectsParentName);
            Vector3 position = structureProjection.transform.parent.localPosition;
            if (dto is BinarySearchNodeDTO castDTO){
                if(castDTO.ParentId != null){
                    GameObject parentObject = GameObject.Find(Constants.NodeName + castDTO.ParentId);
                    position = new Vector3(parentObject.transform.localPosition.x, parentObject.transform.localPosition.y - Constants.VerticalNodeTreeDistance, parentObject.transform.localPosition.z);
                }
            }
            return position;
        }
    }
}