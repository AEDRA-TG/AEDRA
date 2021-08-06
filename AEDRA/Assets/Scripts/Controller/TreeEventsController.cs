using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Events controller that recives all the OnClick methods of the tree options
/// </summary>
public class TreeEventsController : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    /// <summary>
    /// Method that recive the click of the traversal button on options menu delegate prefabs change to OptionsMenu class
    /// </summary>
    public void OnClickTreeTraversal(){
        OptionsMenu optionsMenu = FindObjectOfType<OptionsMenu>();
        optionsMenu.ToggleMenu();
        optionsMenu.LoadPrefab(Constants.PathTraversalOptions, "TreeTraversalOptions", "ProjectionLayout");
        optionsMenu.ShowTittle("Recorrer árbol");
        optionsMenu.ToggleMenu();
    }

    
}
