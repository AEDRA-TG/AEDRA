using UnityEngine;
using Utils.Enums;

namespace Utils.Parameters
{
    /// <summary>
    /// Class that contains information for some target
    /// </summary>
    public class TargetParameter : MonoBehaviour
    {
        /// <summary>
        /// Data structure asocited with the target
        /// </summary>
        [SerializeField] private StructureEnum _structure;

        /// <summary>
        /// Data structure menu prefab asociated with the target
        /// </summary>
        /// <returns></returns>
        [SerializeField] private GameObject _prefabMenu;

        /// <summary>
        /// Target name
        /// </summary>
        /// <returns></returns>
        [SerializeField] private string _dataFilePath;

        [SerializeField] private GameObject _referencePoint;

        [SerializeField] private TargetTypeEnum _targetType;

        public TargetParameter(StructureEnum structure, GameObject prefabMenu, string dataFilePath){
            this._structure = structure;
            this._prefabMenu = prefabMenu;
            this._dataFilePath = dataFilePath;
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
        public void SetDataFilePath(string dataFilePath){
            _dataFilePath = dataFilePath;
        }

        public string GetDataFilePath(){
            return _dataFilePath;
        }

        public void SetReferencePoint(GameObject referencePoint){
            _referencePoint = referencePoint;
        }

        public GameObject GetReferencePoint(){
            return _referencePoint;
        }

        public void SetTargetType(TargetTypeEnum targetType){
            _targetType = targetType;
        }

        public TargetTypeEnum GetTargetType(){
            return _targetType;
        }
    }
}