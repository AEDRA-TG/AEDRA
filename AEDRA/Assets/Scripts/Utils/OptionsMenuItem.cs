using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuItem : MonoBehaviour
{
    [HideInInspector] private Image Img {get; set;}
    //TODO
    [HideInInspector] private Transform Trans;
    private OptionsMenu _optionsMenu;
    private int _index;

    //TODO
    void Awake() {
        Img = GetComponent<Image>();
        Trans = transform;

        _optionsMenu = GameObject.Find("Options").GetComponent<OptionsMenu>();
        _index = Trans.GetSiblingIndex();
    }

    //GETTERS Y SETTERS
    public void SetImg(Image img){
        this.Img = img;
    }

    public Image GetImage(){
        return this.Img;
    }

    public void SetTranform(Transform trans){
        this.Trans = trans;
    }

    public Transform GetTransform(){
        return this.Trans;
    }
}
