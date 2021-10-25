using System;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using Utils.Enums;
using Utils.Parameters;
using View.GUI;
using View.GUI.ProjectedObjects;

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
        /// Id of the previous sub menu that was visible to user
        /// </summary>
        protected MenuEnum _previousActiveSubMenu;

        /// <summary>
        /// Game Object with the actual structure menu
        /// </summary>
        private GameObject _activeMenu;

        /// <summary>
        /// Id of the actual projected data structure
        /// </summary>
        private StructureEnum _activeStructure;

        /// <summary>
        /// Indicates if an structure is projected
        /// </summary>
        private bool _hasProjectedStructure;

        private GameObject _structureProjection;

        public bool IsAnimationControlEnable;

        public static event Action<string> NotifyNotification;

        public void ShowNotification(string notification){
            NotifyNotification?.Invoke(notification);
        }

        /// <summary>
        /// Method that executes when a target is detected by the camera
        /// </summary>
        public void OnTargetDetected(TargetParameter targetParameter){
            //1. First time detecting a target
            if(_activeStructure != targetParameter.GetStructure()){
                //_activeStructure is 'None' by default
                if(_structureProjection != null ){
                    //2. We are changing target - If there is an existing structure we destroy it
                    _structureProjection.SetActive(false);
                    Destroy(_structureProjection);
                    _structureProjection = null;
                }
                //If the is no structure we create a new
                LoadDataStructure(targetParameter.GetReferencePoint().transform);
                //Load target
                _activeStructure = targetParameter.GetStructure();
                Command command = new LoadCommand(_activeStructure, targetParameter.GetDataFilePath());
                CommandController.GetInstance().Invoke(command);
                //Change to respective menu
                LoadStructureMenu( targetParameter.GetPrefabMenu() );
            }
            _hasProjectedStructure = true;
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
            _hasProjectedStructure = false;
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
            _previousActiveSubMenu = _activeSubMenu;
            _activeSubMenu = menu.GetMenu();
            if(_activeSubMenu.ToString().Contains("Input")){
                ClearInputTextField();
            }
            if(menu.GetMenu() == MenuEnum.AnimationControlMenu){
                GameObject backButtonMenu = GameObject.Find(Constants.BackOptionsMenuParent).gameObject;
                backButtonMenu.SetActive(false);
                GameObject hamburger = GameObject.Find(Constants.HamburgerButtonName).gameObject;
                hamburger.SetActive(false);
            }
        }

        /// <summary>
        /// Method that create the information for the next menu
        /// </summary>
        /// <param name="menu">Id of the new menu</param>
        public void ChangeToMenu(MenuEnum menu){
            if(!IsAnimationControlEnable){
                MenuEnumParameter menuEnumParameter = gameObject.GetComponent<MenuEnumParameter>();
                menuEnumParameter.SetMenu(menu);
                ChangeToMenu(menuEnumParameter);
            }
        }


        /// <summary>
        /// Method to detect when the user taps on back button
        /// </summary>
        public void OnTouchBackButton(){
            GameObject backButtonMenu = GameObject.Find(Constants.BackOptionsMenuParent).transform.Find("BackOptionsMenu").gameObject;
            backButtonMenu.SetActive(true);
            backButtonMenu.transform.Find("CleanOption").gameObject.SetActive(_hasProjectedStructure);

        }

        /// <summary>
        /// Method to change to previous menu
        /// </summary>
        public void OnTouchBackToPreviousMenu(){
            if(_activeSubMenu == MenuEnum.AnimationControlMenu){
                GameObject backButtonMenu = GameObject.Find(Constants.MenusParentName).transform.Find(Constants.BackOptionsMenuParent).gameObject;
                backButtonMenu.SetActive(true);
                GameObject hamburger = GameObject.Find(_menus[_activeSubMenu].transform.parent.name).transform.Find(Constants.HamburgerButtonName).gameObject;
                hamburger.SetActive(true);
                IsAnimationControlEnable = false;
                ChangeToMenu(MenuEnum.MainMenu);
                _previousActiveSubMenu = MenuEnum.MainMenu;
            }
            else{
                ChangeToMenu(_previousActiveSubMenu);
            }
        }

        /// <summary>
        /// Method to detect when the user taps on clean structure button
        /// </summary>
        public void OnTouchCleanStructure(){
            Command command = new CleanStructureCommand();
            CommandController.GetInstance().Invoke(command);
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

        /// <summary>
        /// Method to clear input field
        /// </summary>
        public void ClearInputTextField(){
            FindObjectOfType<InputField>().text = "";
        }
        private void LoadStructureMenu(GameObject menu){
            //Destroy previous menu
            if(_activeMenu != null){
                Destroy(_activeMenu); //could be failing
            }
            _activeMenu = Instantiate(menu, new Vector3(0,0,0), Quaternion.identity, GameObject.Find(Constants.MenusParentName).transform);
            _activeMenu.name = menu.name;
            _activeMenu.transform.localPosition = Vector3.zero;
            _activeMenu.transform.SetAsFirstSibling();
        }

        private void LoadDataStructure(Transform unityParent){
            GameObject prefab = Resources.Load(Constants.PrefabPath + Constants.ObjectsParentName) as GameObject;
            _structureProjection = Instantiate(prefab);
            _structureProjection.name = Constants.ObjectsParentName;
            _structureProjection.transform.parent = unityParent;
            _structureProjection.transform.localPosition = Vector3.zero;
            _structureProjection.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        public void OnAlgorithmTargetDetected(TargetParameter targetParameter){
            AppEventController otherInstance = FindObjectOfType<AppEventController>();
            if(otherInstance != this){
                otherInstance.ChangeToMenu(MenuEnum.AnimationControlMenu);
                otherInstance.IsAnimationControlEnable = true;
            }else{
                OnTargetDetected(targetParameter);
            }
        }

        public void OnAlgorithmTargetLost(){
            AppEventController otherInstance = FindObjectOfType<AppEventController>();
            if(otherInstance != this){
                otherInstance.IsAnimationControlEnable = false;
                otherInstance.ChangeToMenu(MenuEnum.MainMenu);
            }else{
                OnTargetLost();
            }
        }
    }
}