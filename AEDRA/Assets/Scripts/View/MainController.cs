using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Controller
{
    /// <summary>
    /// Principal scene controller to manage the events
    /// </summary>
    //TODO: Devolver ticket
    public class MainController : MonoBehaviour
    {
        public void Start()
        {
        }
        public void Update()
        {
        }

        /// <summary>
        /// On click event to open the theme chooser
        /// </summary>
        public void OnClikOpenThemeChooser()
        {
            GameObject themeChooserPrefab = Resources.Load(Constants.PathThemeChooser) as GameObject;
            GameObject themeChooser = Instantiate(themeChooserPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            themeChooser.name = "ThemeChooser";
            themeChooser.transform.parent = GameObject.Find("MainLayout").transform;
        }
    }
}