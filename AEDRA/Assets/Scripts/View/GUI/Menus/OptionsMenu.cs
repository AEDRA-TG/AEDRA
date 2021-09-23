using UnityEngine;
using DG.Tweening;
using Utils;
using UnityEngine.UI;

namespace View
{

    /// <summary>
    /// Class to manage the animations of each submenu
    /// </summary>
    public class OptionsMenu : MonoBehaviour
    {
        /// <summary>
        /// Boolean that indicates if buttuns are expanded
        /// </summary>
        private bool _isExpanded;

        /// <summary>
        /// Array to save the expanded buttons positions
        /// </summary>
        private Vector2[] _originalButtonsPositions;

        /// <summary>
        /// Game object of the hamburguer button
        /// </summary>
        private GameObject _hamburgerButton;

        public void Awake(){
            _hamburgerButton = GameObject.Find(Constants.HamburgerButtonName);
            InitializeSubMenu();
        }

        /// <summary>
        /// Method that is called when the submenu is activated
        /// </summary>
        public void OnEnable() {
            Expand();
            _hamburgerButton.GetComponent<Button>().onClick.RemoveAllListeners();
            _hamburgerButton.GetComponent<Button>().onClick.AddListener(ToggleButtons);
        }

        /// <summary>
        /// Method that is called when the submenu is desactivated
        /// </summary>
        public void OnDisable(){
            Collapse();
        }

        /// <summary>
        /// Method to expand or collapse the buttons depending their actual state
        /// </summary>
        private void ToggleButtons(){
            if(_isExpanded){
                Collapse();
            }
            else{
                Expand();
            }
        }

        /// <summary>
        /// Method to save the buttons expand positions
        /// </summary>
        private void InitializeSubMenu(){
            _isExpanded = false;
            _originalButtonsPositions = new Vector2[this.transform.childCount];

            for (int i = 0; i < _originalButtonsPositions.Length; i++){
                _originalButtonsPositions[i] = this.transform.GetChild(i).position;
                Debug.Log("Hijo: " + i + " " + this.transform.GetChild(i).position);
            }

            MoveButtonAtHamburguerPosition();
        }

        /// <summary>
        /// Method to move all sub menu buttons to the hamburger position
        /// </summary>
        private void MoveButtonAtHamburguerPosition(){
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                this.transform.GetChild(i).transform.position = _hamburgerButton.transform.position;
            }
        }

        /// <summary>
        /// Method to collapse all sub menu buttons to hamburger menu
        /// </summary>
        public void Collapse(){
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                this.transform.GetChild(i).transform.DOMove(_hamburgerButton.transform.position, Constants.CollapseDuration).SetEase(Constants.CollapseEase);
            }
            _isExpanded = false;
        }

        /// <summary>
        /// Method to expand all sub menu buttons
        /// </summary>
        public void Expand(){
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                this.transform.GetChild(i).transform.DOMove(_originalButtonsPositions[i], Constants.ExpandDuration).SetEase(Constants.ExpandEase);
            }
            _isExpanded = true;
        }
    }
}