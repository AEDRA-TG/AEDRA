using UnityEngine;
using Utils.Enums;

namespace Utils.Parameters
{
    public class TargetParameter : MonoBehaviour
    {
        [SerializeField] private StructureEnum _structure;
        [SerializeField] private GameObject _prefabMenu;

        public TargetParameter(StructureEnum structure, GameObject prefabMenu){
            this._structure = structure;
            this._prefabMenu = prefabMenu;
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
    }
}