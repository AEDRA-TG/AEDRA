using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static Color GlobalColor;
    public const string PathHamburgerPrefab = "Prefabs/HamburgerMenu";
    public const string PathLargeButton = "Prefabs/LargeButton";
    public const string PathMainTreeOptions = "Prefabs/MainTreeOptions";
    public const string PathRoundButton = "Prefabs/RoundButton";
    public const string PathThemeChooser = "Prefabs/ThemeChooser";
    public const string PathTraversalOptions = "Prefabs/TreeTraversalOptions";


    void Start(){
        // TODO: LOAD COLOR FROM FILE
        GlobalColor = new Color(0f, 0.5921569f, 1f, 0.7058824f);
    }

}
