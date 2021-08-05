using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static Color GlobalColor;

    void Start(){
        // TODO: LOAD COLOR FROM FILE
        GlobalColor = new Color(0f, 0.5921569f, 1f, 0.7058824f);
    }

}
