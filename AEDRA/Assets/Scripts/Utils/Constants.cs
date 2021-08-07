using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{

    /// <summary>
    /// Class that contains the global constans and configuration atributes
    /// </summary>
    public class Constants : MonoBehaviour
    {
        /// <summary>
        /// Global color of all buttons in the app
        /// </summary>
        public static Color GlobalColor;
        /// <summary>
        /// Path of the hamburger button prefab
        /// </summary>
        public const string PathHamburgerPrefab = "Prefabs/HamburgerMenu";
        /// <summary>
        /// Path of the large button with text prefab
        /// </summary>
        public const string PathLargeButton = "Prefabs/LargeButton";
        /// <summary>
        /// Path of the main tree options prefab
        /// </summary>
        public const string PathMainTreeOptions = "Prefabs/MainTreeOptions";
        /// <summary>
        /// Path of the round button prefab
        /// </summary>
        public const string PathRoundButton = "Prefabs/RoundButton";
        /// <summary>
        /// Path of the theme chooser prefab
        /// </summary>
        public const string PathThemeChooser = "Prefabs/ThemeChooser";
        /// <summary>
        /// Path of the tree traversal options
        /// </summary>
        public const string PathTraversalOptions = "Prefabs/TreeTraversalOptions";


        public void Start()
        {
            // TODO: LOAD COLOR FROM FILE
            GlobalColor = new Color(0f, 0.5921569f, 1f, 0.7058824f);
        }

    }
}