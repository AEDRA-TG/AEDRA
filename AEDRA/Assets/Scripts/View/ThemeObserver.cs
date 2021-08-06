using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeObserver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Method that is invoice when the observer is notified and it change the button color
    /// </summary>
    private void ChangeColor(){
        GetComponent<Image>().color = Constants.GlobalColor;
    }

    /// <summary>
    /// Method to start the observer
    /// </summary>
    private void OnEnable(){
        ThemeController.changeColorDelegate += ChangeColor;
    }
    /// <summary>
    /// Method to stop the observer
    /// </summary>
    private void OnDisable(){
        ThemeController.changeColorDelegate -= ChangeColor;
    }
}
