using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Utils.Enums;
using Utils.Parameters;
using View.GUI;

namespace View.EventController
{
    public class AppEventController: MonoBehaviour
    {
        protected Dictionary<MenuEnum, GameObject> _menus;
        protected MenuEnum _activeSubMenu;
        private GameObject _activeMenu;

        private StructureEnum _activeStructure;
        /// <summary>
        /// Method that executes when a target is detected by the camera
        /// </summary>
        public void OnTargetDetected(TargetParameter targetParameter){
            StructureProjection projection = targetParameter.GetStructureProjection().GetComponent<StructureProjection>();
            targetParameter.GetStructureProjection().SetActive(true);
            Debug.Log("PN: " + projection.Name + " TP: " + targetParameter.GetStructure());
            if(_activeStructure != targetParameter.GetStructure()){
                Debug.Log("Entro al if");
                _activeStructure = targetParameter.GetStructure();
                Command command = new LoadCommand(_activeStructure);
                CommandController.GetInstance().Invoke(command);
                if(_activeMenu != null){
                    Destroy(_activeMenu);
                }
                _activeMenu = Instantiate(targetParameter.GetPrefabMenu(), new Vector3(0,0,0), Quaternion.identity, GameObject.Find(Constants.MenusParentName).transform);
                _activeMenu.transform.localPosition = new Vector3(0,0,0);
            }
            _activeMenu?.SetActive(true);
        }

        /// <summary>
        /// Method that executes when a target is lost by the camera
        /// </summary>
        public void OnTargetLost(){
            GameObject structureProjection = GameObject.Find(Constants.ObjectsParentName);
            _activeMenu?.SetActive(false);
            if(structureProjection != null){
                structureProjection.SetActive(false);
                Command command = new SaveCommand();
                CommandController.GetInstance().Invoke(command);
            }
        }

        public void ChangeToMenu(MenuEnumParameter menu){
            GameObject activeMenu = _menus[_activeSubMenu];
            activeMenu?.SetActive(false);
            GameObject newMenu = _menus[menu.GetMenu()];
            newMenu?.SetActive(true);
            _activeSubMenu = menu.GetMenu();
        }

        protected void ChangeToMenu(MenuEnum menu){
            MenuEnumParameter menuEnumParameter = new MenuEnumParameter();
            menuEnumParameter.SetMenu(menu);
            ChangeToMenu(menuEnumParameter);
        }

        public void ChangeScene(int nextPage)
        {
            SceneManager.LoadScene(nextPage);
        }
    }
}