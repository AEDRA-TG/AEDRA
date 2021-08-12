using Model.Graph;
using UnityEngine;

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
        public string Name {get; set;}
        
        /// <summary>
        /// Type of the structure projection
        /// </summary>
        public string Type {get; set;}

        public void Start(){
            // Projection subscribes to Add Node event for updating UI
            Graph.OnAddNodeEvent += UpdateUI;
        }

        /// <summary>
        /// Method to update the projection on UI
        /// </summary>
        /// <param name="element">Element that will be updated on UI</param>
        private void UpdateUI(object element){
            Debug.Log(element);
        }
    }
}