using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeController : MonoBehaviour
{
    public List<Color> colors;
    public delegate void ChangeColorDelegate();
    public static ChangeColorDelegate changeColorDelegate;

    // Start is called before the first frame update
    void Start()
    {
        colors = new List<Color>();
        colors.Add(new Color(0.4156863f, 0.07450981f, 0.8313726f, 0.7058824f));
        colors.Add(new Color(0f, 0.5921569f, 1f, 0.7058824f));
        colors.Add(new Color(0.509804f, 0.509804f, 0.509804f, 0.7058824f));
        colors.Add(new Color(0.1372549f, 0.9098039f, 0.6666667f, 0.7058824f));
        GameObject acceptButton = GameObject.Find("AcceptButton");
        acceptButton = acceptButton.transform.GetChild(0).gameObject;
        acceptButton.GetComponent<Image>().color = Constants.GlobalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(int idColor){
        GameObject acceptButton = GameObject.Find("AcceptButton");
        acceptButton = acceptButton.transform.GetChild(0).gameObject;
        acceptButton.GetComponent<Image>().color = colors[idColor];
        Constants.GlobalColor = colors[idColor];
    }

    public void ChangeGlobalColor(){
        changeColorDelegate?.Invoke();
        PersistPrefabs();
        CloseThemeChooser();
    }

    public void CloseThemeChooser(){
        GameObject themeChooser = GameObject.Find("ThemeChooser");
        Destroy(themeChooser);
    }

    private void PersistPrefabs(){
        GameObject largeButtonPrefab = Resources.Load("Prefabs/LargeButton") as GameObject;
        largeButtonPrefab.GetComponent<Image>().color = Constants.GlobalColor;
        GameObject roundedButtonPrefab = Resources.Load("Prefabs/RoundButton") as GameObject;
        roundedButtonPrefab.GetComponent<Image>().color = Constants.GlobalColor;
    }

}
