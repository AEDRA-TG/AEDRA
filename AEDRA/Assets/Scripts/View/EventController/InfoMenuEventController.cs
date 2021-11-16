using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View.EventController
{
    /// <summary>
    /// Class to manage all the initial application configuration
    /// </summary>
    public class InfoMenuEventController : MonoBehaviour
    {
        /// <summary>
        /// Prefab that shows the first time
        /// </summary>
        private GameObject _startInfoPrefab;

        public void Start()
        {
            if (PlayerPrefs.GetInt("FirstTimeOpening", 1) == 1)
            {
                PlayerPrefs.SetInt("FirstTimeOpening", 0);
                if (SceneManager.GetActiveScene().name == "Main")
                {
                    _startInfoPrefab = GameObject.Find("MainLayout").transform.Find("StartInfoMenu").gameObject;
                    _startInfoPrefab?.SetActive(true);
                }
            }
        }

        /// <summary>
        /// Method for hidding the start info menu prefab on the main scene
        /// </summary>
        public void HideStartInfoMenuPrefab() {
            _startInfoPrefab?.SetActive(false);
        }
    }
}