using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject acceptButton = GameObject.Find("StartButton");
        acceptButton.GetComponent<Image>().color = Constants.globalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openThemeChooser(){
        GameObject themeChooserPrefab = Resources.Load("Prefabs/ThemeChooser") as GameObject;
        GameObject themeChooser = Instantiate(themeChooserPrefab, new Vector3(0,0,0), Quaternion.identity);
        themeChooser.name = "ThemeChooser";
        themeChooser.transform.parent = GameObject.Find("MainLayout").transform;
    }
}
