using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    // Start is called before the first frame update
    void Start()
    {
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
        _hamburgerButton.onClick.AddListener(ToggleMenu);
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

    private void ToggleMenu()
    {
        if (!_isExpanded)
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                ExpandOrCallapse(_optionItems[i], _itemsPositions[i], ExpandDuration, ExpandFadeDuration, ExpandEase, 0.7f);
            }
        }
        else
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                ExpandOrCallapse(_optionItems[i], _hamburgerButtonPosition, CollapseDuration, CollapseFadeDuration, CollapseEase, 0.0f);
            }
        }
        _isExpanded = !_isExpanded;
    }

    private void ExpandOrCallapse(OptionsMenuItem item, Vector2 position, float duration, 
        float fadeDuration, Ease easeAnimation, float fadePosition){
        item.GetTransform().DOMove(position, duration).SetEase(easeAnimation);
        item.GetImage().DOFade(fadePosition, fadeDuration).From(0f);
    }

    private void OnDestroy()
    {
        _hamburgerButton.onClick.RemoveListener(ToggleMenu);
    }

    public void OnItemClick(int index)
    {
        switch (index)
        {
            case 0:
                //Utils.sendToast("Añadir nodo");

                break;
            case 1:
                //Utils.sendToast("Eliminar nodo");
                break;

            case 2:
                //Utils.sendToast("Recorrer ED");
                break;
        }
    }
}
