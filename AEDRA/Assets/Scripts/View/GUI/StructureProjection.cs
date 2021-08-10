using Model.Graph;
using UnityEngine;

namespace View.GUI
{
    public class StructureProjection : MonoBehaviour
    {
        public string Name {get; set;}
        public string Type {get; set;}

        public void Start(){
            Graph.OnAddNodeEvent += UpdateUI;
        }

        private void UpdateUI(object element){
            Debug.Log(element);
        }
    }
}