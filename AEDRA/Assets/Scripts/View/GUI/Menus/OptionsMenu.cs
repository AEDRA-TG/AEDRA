using UnityEngine;
using DG.Tweening;
using Utils;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            ShowHelpButtonMenu();
            InitializeSubMenu();
        }

        /// <summary>
        /// Method to show Help Button Menu when user open the app for first time
        /// </summary>
        public void ShowHelpButtonMenu() {
            if (PlayerPrefs.GetInt("FirstTargetDetected", 1) == 1)
            {
                PlayerPrefs.SetInt("FirstTargetDetected", 0);
                if(SceneManager.GetActiveScene().name == "Projection")
                {
                    GameObject.Find(Constants.HelpButtonMenuName).transform.GetChild(0).GetComponent<Image>().DOFade(0f, 6).From(1f);
                    GameObject.Find(Constants.HelpButtonMenuName).transform.GetChild(0).GetChild(0).GetComponent<Text>().DOFade(0f, 6).From(1f);
                }
            } else {
                GameObject.Find(Constants.HelpButtonMenuName)?.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Method that is called when the submenu is activated
        /// </summary>
        public void OnEnable() {
            Expand();
            if(_hamburgerButton != null){
                _hamburgerButton.GetComponent<Button>().onClick.RemoveAllListeners();
                _hamburgerButton.GetComponent<Button>().onClick.AddListener(ToggleButtons);
            }
            GameObject.Find(Constants.InfoButtonName).GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find(Constants.InfoButtonName).GetComponent<Button>().onClick.AddListener(ShowTooltips);
        }

        /// <summary>
        /// Method that is called when the submenu is desactivated
        /// </summary>
        public void OnDisable(){
            Collapse();
        }

        /// <summary>
        /// Method to execute an animation for showing tooltips
        /// </summary>
        public void ShowTooltips(){
            if(!_isExpanded){
                Expand();
            }
            Sequence showList = DOTween.Sequence();
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                if(this.transform.GetChild(i).Find(Constants.TooltipName)!=null){
                    this.transform.GetChild(i).Find(Constants.TooltipName).gameObject.SetActive(true);
                    this.transform.GetChild(i).Find(Constants.TooltipName).GetComponent<Image>().DOFade(0f, 0).From(1f);
                    this.transform.GetChild(i).Find(Constants.TooltipName).transform.GetChild(0).GetComponent<Text>().DOFade(0f, 0).From(1f);
                    showList.Join(this.transform.GetChild(i).Find(Constants.TooltipName).GetComponent<Image>().DOFade(1f, 2).From(0f));
                    showList.Join(this.transform.GetChild(i).Find(Constants.TooltipName).transform.GetChild(0).GetComponent<Text>().DOFade(1f, 2).From(0f));
                }
            }
            showList.OnComplete(() => HideTooltipsAnimation());
        }

        /// <summary>
        /// Method to execute an animation for hidding tooltips
        /// </summary>
        public void HideTooltipsAnimation(){
            Sequence hideList = DOTween.Sequence();
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                hideList.Join(this.transform.GetChild(i).Find(Constants.TooltipName).GetComponent<Image>().DOFade(0f, 3).From(1f));
                hideList.Join(this.transform.GetChild(i).Find(Constants.TooltipName).transform.GetChild(0).GetComponent<Text>().DOFade(0f, 3).From(1f));
            }
            hideList.OnComplete(() => HideTooltips());
        }

        /// <summary>
        /// Method to hide the tooltips
        /// </summary>
        public void HideTooltips(){
            for(int i = 0; i < _originalButtonsPositions.Length; i++){
                this.transform.GetChild(i).Find(Constants.TooltipName).gameObject.SetActive(false);
            }
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
            }

            MoveButtonAtHamburguerPosition();
        }

        /// <summary>
        /// Method to move all sub menu buttons to the hamburger position
        /// </summary>
        private void MoveButtonAtHamburguerPosition(){
            if(_hamburgerButton != null){
                for(int i = 0; i < _originalButtonsPositions.Length; i++){
                    this.transform.GetChild(i).transform.position = _hamburgerButton.transform.position;
                }
            }
        }

        /// <summary>
        /// Method to collapse all sub menu buttons to hamburger menu
        /// </summary>
        public void Collapse(){
            if(_hamburgerButton != null){
                for(int i = 0; i < _originalButtonsPositions.Length; i++){
                    this.transform.GetChild(i).transform.DOMove(_hamburgerButton.transform.position, Constants.CollapseDuration).SetEase(Constants.CollapseEase);
                }
                _isExpanded = false;
            }
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