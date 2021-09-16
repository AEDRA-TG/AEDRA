using UnityEngine;
using UnityEngine.UI;
using Utils;
using Controller;

namespace Observer
{
    public class ThemeObserver : MonoBehaviour
    {
        public void Start()
        {
            GetComponent<Image>().color = Constants.GlobalColor;
        }

        public void Update()
        {

        }

        /// <summary>
        /// Method that is invoice when the observer is notified and it change the button color
        /// </summary>
        private void ChangeColor()
        {
            GetComponent<Image>().color = Constants.GlobalColor;
        }

        /// <summary>
        /// Method to start the observer
        /// </summary>
        public void OnEnable()
        {
            ThemeController.changeColorDelegate += ChangeColor;
        }
        /// <summary>
        /// Method to stop the observer
        /// </summary>
        public void OnDisable()
        {
            ThemeController.changeColorDelegate -= ChangeColor;
        }
    }
}