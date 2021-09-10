using UnityEngine;
using Utils.Enums;

namespace Utils.Parameters
{
    public class TargetParameter : MonoBehaviour
    {
        [SerializeField] private StructureEnum _structure;
        [SerializeField] private GameObject _prefabMenu;
        [SerializeField] private string _targetName;

        public TargetParameter(StructureEnum structure, GameObject prefabMenu, string targetName){
            this._structure = structure;
            this._prefabMenu = prefabMenu;
            this._targetName = targetName;
        }
        public void SetStructure(StructureEnum structure){
            _structure = structure;
        }

        public StructureEnum GetStructure(){
            return _structure;
        }
        public void SetPrefabMenu(GameObject prefabMenu){
            _prefabMenu = prefabMenu;
        }

        public GameObject GetPrefabMenu(){
            return _prefabMenu;
        }
        public void SetTargetName(string targetName){
            _targetName = targetName;
        }

        public string GetTargetName(){
            return _targetName;
        }
    }
}