using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
using System.Threading;

public class OptionsMenu : MonoBehaviour
{
    [Space]
    [Header("Animation")]
    [SerializeField] private float ExpandDuration;

    [SerializeField] private float CollapseDuration;
    [SerializeField] private Ease ExpandEase;
    [SerializeField] private Ease CollapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] private float ExpandFadeDuration;
    [SerializeField] private float CollapseFadeDuration;

    private Button _hamburgerButton;
    private OptionsMenuItem[] _optionItems;
    private bool _isExpanded;
    private Vector2 _hamburgerButtonPosition;
    private int _itemsCount;
    private Vector2[] _itemsPositions;
    private Stack<string> _loadedPrefabs;
    private string actualPrefabName;

    // Start is called before the first frame update
    void Start(){
        _loadedPrefabs = new Stack<string>();
        actualPrefabName = "";
        LoadPrefab(Constants.PathMainTreeOptions, "MainTreeOptions", "ProjectionLayout");
    }
    public void LoadPrefab(string prefabPath, string instanceName, string parent){
        DestroyActualPrefabInstance();
        GameObject firstPrefab = Resources.Load(prefabPath) as GameObject;
        GameObject firstPrefabInstantiate = Instantiate(firstPrefab, new Vector3(0,0,0), Quaternion.identity);
        firstPrefabInstantiate.name = instanceName;
        actualPrefabName = instanceName;
        firstPrefabInstantiate.transform.parent = GameObject.Find(parent).transform;
        firstPrefabInstantiate.transform.SetAsFirstSibling();
        _loadedPrefabs.Push(prefabPath);
        InitializeComponents();
    }

    public void ShowTittle(string tittle){
        GameObject textTittle = GameObject.Find("CurrentActionTitle");
        textTittle.GetComponent<Text>().text = tittle;
        textTittle.GetComponent<Text>().DOFade(1f, 2).From(0f).OnComplete(()=>{textTittle.GetComponent<Text>().DOFade(0f, 4).From(1f);});

    }
    private void DestroyActualPrefabInstance(){
        if(!actualPrefabName.Equals("")){
            GameObject prefab = GameObject.Find(actualPrefabName);
            //Destroy(prefab);
            prefab.SetActive(false);
        }
        
    }
    private void InitializeComponents(){
        GameObject itemsInScene = GameObject.Find("Options");
        _itemsCount = itemsInScene.transform.childCount;
        _optionItems = new OptionsMenuItem[_itemsCount];
        _itemsPositions = new Vector2[_itemsCount];
        for (int i = 0; i < _itemsCount; i++)
        {
            _optionItems[i] = itemsInScene.transform.GetChild(i).GetComponent<OptionsMenuItem>();
            _itemsPositions[i] = _optionItems[i].transform.position;
        }
        //inflate hamburger menu
        _hamburgerButton = GameObject.Find("HamburgerMenu").GetComponentInChildren<Button>();
        _hamburgerButton.transform.SetAsLastSibling();
        //save position of hamburguer position
        _hamburgerButtonPosition = _hamburgerButton.transform.position;
        ResetPositions();
    }
    //
    private void ResetPositions()
    {
        for (int i = 0; i < _itemsCount; i++)
        {
            _optionItems[i].GetTransform().position = _hamburgerButtonPosition;
        }
    }

    public void ToggleMenu()
    {
        if (!_isExpanded)
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                ExpandOrCollapse(_optionItems[i], _itemsPositions[i], ExpandDuration, ExpandFadeDuration, ExpandEase, 0.7f);
            }
        }
        else
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                ExpandOrCollapse(_optionItems[i], _hamburgerButtonPosition, CollapseDuration, CollapseFadeDuration, CollapseEase, 0.0f);
            }
        }
        _isExpanded = !_isExpanded;
    }

    private void ExpandOrCollapse(OptionsMenuItem item, Vector2 position, float duration, 
        float fadeDuration, Ease easeAnimation, float fadeOpacity){
        item.GetTransform().DOMove(position, duration).SetEase(easeAnimation);
        item.GetImage().DOFade(fadeOpacity, fadeDuration).From(0f);
    }

    private void OnDestroy()
    {
        _hamburgerButton.onClick.RemoveListener(ToggleMenu);
    }
}
