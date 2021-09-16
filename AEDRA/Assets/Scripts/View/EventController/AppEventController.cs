using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
            GameObject optionsMenu = GameObject.Find("BackButton");
            optionsMenu.GetComponent<Button>().onClick.RemoveAllListeners();

            GameObject structureProjection = GameObject.Find(Constants.ObjectsParentName);
            if(_activeStructure != targetParameter.GetStructure()){
                Destroy(structureProjection);
                structureProjection = null;
            }
            if(structureProjection==null){
                structureProjection = new GameObject(Constants.ObjectsParentName, typeof(StructureProjection));
                structureProjection.transform.parent = GameObject.Find(targetParameter.GetTargetName()).transform;
            }
            if(_activeStructure != targetParameter.GetStructure()){
                _activeStructure = targetParameter.GetStructure();
                Command command = new LoadCommand(_activeStructure);
                CommandController.GetInstance().Invoke(command);
                if(_activeMenu != null){
                    Destroy(_activeMenu);
                }
                _activeMenu = Instantiate(targetParameter.GetPrefabMenu(), new Vector3(0,0,0), Quaternion.identity, GameObject.Find(Constants.MenusParentName).transform);
                _activeMenu.name = targetParameter.GetPrefabMenu().name;
                _activeMenu.transform.localPosition = new Vector3(0,0,0);
                _activeMenu.transform.SetAsFirstSibling();
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
                Command command = new SaveCommand();
                CommandController.GetInstance().Invoke(command);
            }
            GameObject optionsMenu = GameObject.Find("BackButton");
            optionsMenu.GetComponent<Button>().onClick.AddListener(delegate{ChangeScene(0);});
        }

        public void ChangeToMenu(MenuEnumParameter menu){
            GameObject activeMenu = _menus[_activeSubMenu];
            activeMenu?.SetActive(false);
            GameObject newMenu = _menus[menu.GetMenu()];
            newMenu?.SetActive(true);
            _activeSubMenu = menu.GetMenu();
        }

        public void ChangeToMenu(MenuEnum menu){
            MenuEnumParameter menuEnumParameter = new MenuEnumParameter();
            menuEnumParameter.SetMenu(menu);
            ChangeToMenu(menuEnumParameter);
        }

        private void ShowOptionsMenu(bool state){
            GameObject optionsMenu = GameObject.Find("BackButton");
            optionsMenu.transform.Find("BackOptionsMenu").gameObject.SetActive(state);
        }

        public void OnTouchBackButton(){
            if(_activeSubMenu != MenuEnum.MainMenu){
                ChangeToMenu(MenuEnum.MainMenu);
            }
            else{
                ShowOptionsMenu(true);
            }
        }

        public void OnTouchCleanStructure(){
            Command command = new CleanStructureCommand();
            CommandController.GetInstance().Invoke(command);
            ShowOptionsMenu(false);
        }
        public void ChangeScene(int nextPage)
        {
            GameObject structureProjection = GameObject.Find(Constants.ObjectsParentName);
            if(structureProjection != null){
                Command command = new SaveCommand();
                CommandController.GetInstance().Invoke(command);
            }
            SceneManager.LoadScene(nextPage);
        }
    }
}