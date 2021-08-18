using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;
using Utils;

namespace View.EventController
{
    /// <summary>
    /// Events controller that recives all the OnClick methods of the tree options
    /// </summary>
    public class TreeEventsController : MonoBehaviour
    {
        public void Start()
        {
        }
        public void Update()
        {
        }
        /// <summary>
        /// Method that recive the click of the traversal button on options menu delegate prefabs change to OptionsMenu class
        /// </summary>
        /// <param name="prefabPath">The text that indicates the prefabs path</param>
        /// <param name="instanceName">The name that instance prefab will have</param>
        /// <param name="parent">The parent of the prefab name</param>

        public void OnClickTreeTraversal()
        {
            OptionsMenu optionsMenu = FindObjectOfType<OptionsMenu>();
            optionsMenu.ToggleMenu();
            optionsMenu.LoadPrefab(Constants.PathTraversalOptions, "TreeTraversalOptions", "ProjectionLayout");
            optionsMenu.ShowTittle("Recorrer árbol");
            optionsMenu.ToggleMenu();
        }
    }
}