using System.Collections.Generic;
using Model.Common;
using Model.SideCar.DTOs;
using UnityEngine;
using Utils;

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
        public string Name { get; set; }

        /// <summary>
        /// Type of the structure projection
        /// </summary>
        public string Type { get; set; }
        public List<DataStructureElementDTO> DTOs {get; set;}
        public List<ProjectedObject> ProjectedObjects {get; set;}
        public void Awake()
        {
            DTOs = new List<DataStructureElementDTO>();
            //TODO: initialize already existing objects in list
            ProjectedObjects = new List<ProjectedObject>();
        }
        public void AddDto(DataStructureElementDTO dto)
        {
            DTOs.Add(dto);
            string id = "Node_" + dto.Id;
            ProjectedObject obj = MapProjectedObject("Node_"+ id, Constants.PathGraphNode);
            obj.SetDTO(dto);
        }

        public ProjectedObject MapProjectedObject(string Id, string prefabPath)
        {
            //TODO: no me gusta esto, att: Santamaria 
            GameObject obj = GameObject.Find(Id);
            if (obj == null)
            {
                GameObject prefab = Resources.Load(prefabPath) as GameObject;
                //TODO: Review who should make this call
                obj = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
                obj.name = Id;
                ProjectedObjects.Add(obj.GetComponentInChildren<ProjectedObject>());
            }
            return obj.GetComponentInChildren<ProjectedObject>();
        }
    }
}