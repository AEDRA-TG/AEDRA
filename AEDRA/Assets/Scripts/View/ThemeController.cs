using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Controller
{

    /// <summary>
    /// Class to manage the colors of the aplication
    /// </summary>
    public class ThemeController : MonoBehaviour
    {
        /// <summary>
        /// List of the possible colors that the user can use
        /// </summary>
        private List<Color> _colors;
        /// <summary>
        /// Delegete for the observer that change the color of the buttons
        /// </summary>
        public delegate void ChangeColorDelegate();
        public static ChangeColorDelegate changeColorDelegate;

        public void Awake() {
            _colors = new List<Color>();
        }
        public void Start()
        {
            _colors.Add(new Color(0.4156863f, 0.07450981f, 0.8313726f, 0.7058824f));
            _colors.Add(new Color(0f, 0.5921569f, 1f, 0.7058824f));
            _colors.Add(new Color(0.509804f, 0.509804f, 0.509804f, 0.7058824f));
            _colors.Add(new Color(0.1372549f, 0.9098039f, 0.6666667f, 0.7058824f));
            GameObject acceptButton = GameObject.Find("AcceptButton");
            acceptButton = acceptButton.transform.GetChild(0).gameObject;
            acceptButton.GetComponent<Image>().color = Constants.GlobalColor;
        }

        public void Update()
        {

        }

        /// <summary>
        /// Method to change the accept button to show an user color preview
        /// </summary>
        /// <param name="idColor">Index of the selected color by the user</param>
        public void ChangeColor(int idColor)
        {
            GameObject acceptButton = GameObject.Find("AcceptButton");
            acceptButton = acceptButton.transform.GetChild(0).gameObject;
            acceptButton.GetComponent<Image>().color = _colors[idColor];
            Utilities.SaveGlobalColor(_colors[idColor]);
        }

        /// <summary>
        /// Method to notify the observers and call the persist method color
        /// </summary>
        public void ChangeGlobalColor()
        {
            changeColorDelegate?.Invoke();
            PersistPrefabs();
            CloseThemeChooser();
        }
        /// <summary>
        /// Method to close the theme chooser
        /// </summary>
        public void CloseThemeChooser()
        {
            GameObject themeChooser = GameObject.Find("ThemeChooser");
            Destroy(themeChooser);
        }
        /// <summary>
        /// Method to persist the selected color in all buttons prefabs
        /// </summary>
        private void PersistPrefabs()
        {
            GameObject largeButtonPrefab = Resources.Load(Constants.PathLargeButton) as GameObject;
            largeButtonPrefab.GetComponent<Image>().color = Constants.GlobalColor;
            GameObject roundedButtonPrefab = Resources.Load(Constants.PathRoundButton) as GameObject;
            roundedButtonPrefab.GetComponent<Image>().color = Constants.GlobalColor;
        }

    }
}