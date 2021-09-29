using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Controller
{

    /// <summary>
    /// Class to manage the colors of the aplication
    /// </summary>
    public class ThemeChooserEventController : MonoBehaviour
    {
        /// <summary>
        /// List of the possible colors that the user can use
        /// </summary>
        private List<Color> _colors;

        /// <summary>
        /// Delegete for the observer that change the color of the buttons
        /// </summary>
        public delegate void ChangeColorDelegate();

        /// <summary>
        /// Delegate for the observer that change the color
        /// </summary>
        public static ChangeColorDelegate changeColorDelegate;

        /// <summary>
        /// Atribute to save the actual selected color by user
        /// </summary>
        private int _actualColor;

        public void Awake() {
            _colors = new List<Color>();
        }

        public void Start()
        {
            Transform chooser = gameObject.transform.Find(Constants.ChooserName);
            for(int i = 2; i < chooser.childCount; i++){
                _colors.Add(chooser.GetChild(i).GetComponent<Image>().color);
            }
            /*GameObject acceptButton = GameObject.Find("AcceptButton");
            acceptButton = acceptButton.transform.GetChild(0).gameObject;
            acceptButton.GetComponent<Image>().color = Constants.GlobalColor;*/
        }

        /// <summary>
        /// Method to change the accept button to show an user color preview
        /// </summary>
        /// <param name="idColor">Index of the selected color by the user</param>
        public void ChangeColor(int idColor)
        {
            _actualColor = idColor;
            GameObject acceptButton = GameObject.Find("AcceptButton");
            acceptButton.GetComponent<Image>().color = _colors[idColor];
        }

        /// <summary>
        /// Method to notify the observers and call the persist method color
        /// </summary>
        public void ChangeGlobalColor()
        {
            Utilities.SaveGlobalColor(_colors[_actualColor]);
            changeColorDelegate?.Invoke();
        }

        public void ActivateThemeChooser(bool status){
            gameObject.SetActive(status);
        }

    }
}