using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEventsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickTreeTraversal(){
        OptionsMenu optionsMenu = FindObjectOfType<OptionsMenu>();
        optionsMenu.ToggleMenu();
        optionsMenu.LoadPrefab(Constants.PathTraversalOptions, "TreeTraversalOptions", "ProjectionLayout");
        optionsMenu.ShowTittle("Recorrer árbol");
        optionsMenu.ToggleMenu();
    }

    
}
