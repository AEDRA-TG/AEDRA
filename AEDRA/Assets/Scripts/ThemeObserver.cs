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

    private void ChangeColor(){
        GetComponent<Image>().color = Constants.globalColor;
    }

    private void OnEnable(){
        ThemeController.changeColorDelegate += ChangeColor;
    }

    private void OnDisable(){
        ThemeController.changeColorDelegate -= ChangeColor;
    }
}
