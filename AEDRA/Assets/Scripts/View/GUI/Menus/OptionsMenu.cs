using UnityEngine;
using DG.Tweening;
using Utils;
using UnityEngine.UI;

namespace View
{

    /// <summary>
    /// Class of the item that could be animated
    /// </summary>
    public class OptionsMenu : MonoBehaviour
    {
        private bool _isExpanded;

        private Vector2[] _originalButtonsPositions;

        private GameObject _hamburgerButton;
        public void Awake(){
            _hamburgerButton = GameObject.Find(Constants.HamburgerButtonName);
            InitializeSubMenu();
        }

        public void OnEnable() {
            Expand();
            _hamburgerButton.GetComponent<Button>().onClick.RemoveAllListeners();
            _hamburgerButton.GetComponent<Button>().onClick.AddListener(ToggleButtons);
        }

        public void OnDisable(){
            Collapse();
        }

        private void ToggleButtons(){
            if(_isExpanded){
                Collapse();
            }
            else{
                Expand();
            }
        }

        private void InitializeSubMenu(){
            _isExpanded = false;
            _originalButtonsPositions = new Vector2[this.transform.childCount];
            for (int i = 0; i < _originalButtonsPositions.Length; i++){
                _originalButtonsPositions[i] = this.transform.GetChild(i).position;
                Debug.Log("Hijo: " + i + " " + this.transform.GetChild(i).position);
            }
            MoveButtonAtHamburguerPosition();
        }

        private void MoveButtonAtHamburguerPosition(){
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                this.transform.GetChild(i).transform.position = _hamburgerButton.transform.position;
            }
        }
        /// <summary>
        /// Method to do the expand or collapse animation depending on the parameters
        /// </summary>
        public void Collapse(){
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                this.transform.GetChild(i).transform.DOMove(_hamburgerButton.transform.position, Constants.CollapseDuration).SetEase(Constants.CollapseEase);
            }
            _isExpanded = false;
        }

        public void Expand(){
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                this.transform.GetChild(i).transform.DOMove(_originalButtonsPositions[i], Constants.ExpandDuration).SetEase(Constants.ExpandEase);
            }
            _isExpanded = true;
        }
    }
}