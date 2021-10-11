using System.Collections.Generic;
using SideCar.DTOs;
using UnityEngine;
using Utils;
using Utils.Enums;
using View.Animations;
using View.Animations.Algorithms;
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

        /// <summary>
        /// List dtos asociated to the projected objects on projection
        /// </summary>
        public List<ElementDTO> DTOs {get; set;}

        /// <summary>
        /// List of the actual projected objects
        /// </summary>
        public List<ProjectedObject> ProjectedObjects {get; set;}

        /// <summary>
        /// Dictionary that contains all the animations for the projection
        /// </summary>
        private Dictionary<OperationEnum, IAnimationStrategy> _animations;

        /// <summary>
        /// Reference point to instanciate objects
        /// </summary>
        private Transform _referencePoint;

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
                { OperationEnum.UpdateObjects, new UpdateAnimation() },
                { OperationEnum.Algorithm, new AlgorithmAnimation()}
            };
            _referencePoint = GameObject.Find(Constants.ReferencePointName).transform;
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
            if(dto.Operation != AnimationEnum.CreateAnimation){
                GameObject obj = GameObject.Find(dto.GetUnityId());
                obj?.GetComponent<ProjectedObject>().UpdateDTO(dto);
            }
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
        /// <returns>The projected object asociated with the created object</returns>
        public ProjectedObject CreateObject(ElementDTO dto, Vector3? coordinates = null){
            Vector3 position;
            if(coordinates != null){
                position = coordinates ?? default;
            }
            else{
                position = CalculateInitialPosition(dto);
            }
            string prefabPath = Constants.PrefabPath + dto.Name;
            GameObject prefab = Resources.Load(prefabPath) as GameObject;
            prefab = Instantiate(prefab,this.transform);
            prefab.transform.localPosition = position;
            prefab.transform.localRotation = Quaternion.Euler(90,0,0);
            prefab.name = dto.GetUnityId();
            ProjectedObject createdObject = prefab.GetComponent<ProjectedObject>();
            createdObject.SetDTO(dto);

            // Activate selectable object if is Graph element
            if(dto is GraphNodeDTO){
                createdObject.SetSelectable(true);
            }
            if(coordinates == null){
                createdObject.PositionObject();
            }
            ProjectedObjects.Add(createdObject);
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

        /// <summary>
        /// Method to calculates the position in wich a new object will be created
        /// </summary>
        /// <param name="dto">The information of the new object</param>
        /// <returns>Coordinates to instanciate the object</returns>
        public Vector3 CalculateInitialPosition(ElementDTO dto){
            //Calcular las coordenadas
            Vector3 objectPosition;
            if(dto is BinarySearchNodeDTO binaryDTO){
                if(binaryDTO.ParentId == null){
                    objectPosition = new Vector3(_referencePoint.localPosition.x,_referencePoint.localPosition.y,-1.5f);
                }
                else{
                    GameObject parentNode = GameObject.Find(Constants.NodeName + binaryDTO.ParentId);
                    objectPosition = new Vector3(parentNode.transform.localPosition.x, parentNode.transform.localPosition.y - Constants.VerticalNodeTreeDistance, parentNode.transform.localPosition.z);
                }
            }
            else{
                objectPosition = new Vector3(Random.Range(-5, 5),_referencePoint.localPosition.y,Random.Range(0, -(_referencePoint.transform.localPosition.z*2)));
            }
            return objectPosition;
        }
    }
}