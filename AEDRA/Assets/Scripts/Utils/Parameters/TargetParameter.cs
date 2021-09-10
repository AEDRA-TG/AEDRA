using UnityEngine;
using Utils.Enums;

namespace Utils.Parameters
{
    public class TargetParameter : MonoBehaviour
    {
        [SerializeField] private StructureEnum _structure;
        [SerializeField] private GameObject _prefabMenu;
        [SerializeField] private GameObject _structureProjection;

        public TargetParameter(StructureEnum structure, GameObject prefabMenu, GameObject structureProjection){
            this._structure = structure;
            this._prefabMenu = prefabMenu;
            this._structureProjection = structureProjection;
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
        public void SetStructureProjection(GameObject structureProjection){
            _structureProjection = structureProjection;
        }

        public GameObject GetStructureProjection(){
            return _structureProjection;
        }
    }
}