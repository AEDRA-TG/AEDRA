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
    /// <summary>
    /// Class to manage the principal event system
    /// </summary>
    public class AppEventController: MonoBehaviour
    {
        /// <summary>
        /// Dictionary that contains the actual data structure menus
        /// </summary>
        protected Dictionary<MenuEnum, GameObject> _menus;

        /// <summary>
        /// Id of the actual sub menu that is visible to user
        /// </summary>
        protected MenuEnum _activeSubMenu;

        /// <summary>
        /// Game Object with the actual structure menu
        /// </summary>
        private GameObject _activeMenu;

        /// <summary>
        /// Id of the actual projected data structure
        /// </summary>
        private StructureEnum _activeStructure;

        //TODO: regañar a Andrés
        public void Update(){
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                //ShowOptionsMenu(false);
            }
#elif UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                   // ShowOptionsMenu(false);
                }
            }
#endif
        }

        /// <summary>
        /// Method that executes when a target is detected by the camera
        /// </summary>
        public void OnTargetDetected(TargetParameter targetParameter){
            GameObject optionsMenu = GameObject.Find("BackButton");
            optionsMenu.GetComponent<Button>().onClick.RemoveAllListeners();
            optionsMenu.GetComponent<Button>().onClick.AddListener(OnTouchBackButton);
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
            GameObject optionsMenu = GameObject.Find("BackButton");
            optionsMenu.GetComponent<Button>().onClick.RemoveAllListeners();
            ShowOptionsMenu(false);
            GameObject structureProjection = GameObject.Find(Constants.ObjectsParentName);
            _activeMenu?.SetActive(false);
            if(structureProjection != null){
                Command command = new SaveCommand();
                CommandController.GetInstance().Invoke(command);
            }
            optionsMenu.GetComponent<Button>().onClick.AddListener(delegate{ChangeScene(0);});
        }

        /// <summary>
        /// Method to change the actual sub menu
        /// </summary>
        /// <param name="menu">Information about the next menu</param>
        public void ChangeToMenu(MenuEnumParameter menu){
            GameObject activeMenu = _menus[_activeSubMenu];
            activeMenu?.SetActive(false);
            GameObject newMenu = _menus[menu.GetMenu()];
            newMenu?.SetActive(true);
            _activeSubMenu = menu.GetMenu();
        }

        /// <summary>
        /// Method that create the information for the next menu
        /// </summary>
        /// <param name="menu">Id of the new menu</param>
        public void ChangeToMenu(MenuEnum menu){
            MenuEnumParameter menuEnumParameter = new MenuEnumParameter();
            menuEnumParameter.SetMenu(menu);
            ChangeToMenu(menuEnumParameter);
        }

        /// <summary>
        /// Method to activate o desactive the options menu
        /// </summary>
        /// <param name="state">True if do you want to active the menu, false otherwise</param>
        private void ShowOptionsMenu(bool state){
            GameObject optionsMenu = GameObject.Find("BackButton");
            optionsMenu.transform.Find("BackOptionsMenu").gameObject.SetActive(state);
        }

        /// <summary>
        /// Method to detect when the user taps on back button
        /// </summary>
        public void OnTouchBackButton(){
            if(_activeSubMenu != MenuEnum.MainMenu){
                ChangeToMenu(MenuEnum.MainMenu);
            }
            else{
                ShowOptionsMenu(true);
            }
        }

        /// <summary>
        /// Method to detect when the user taps on clean structure button
        /// </summary>
        public void OnTouchCleanStructure(){
            Command command = new CleanStructureCommand();
            CommandController.GetInstance().Invoke(command);
            ShowOptionsMenu(false);
        }

        /// <summary>
        /// Method to change between scenes
        /// </summary>
        /// <param name="nextPage">Id of the next scene</param>
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