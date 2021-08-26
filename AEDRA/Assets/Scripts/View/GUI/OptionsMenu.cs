using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
using System.Threading;
using Utils;
using View.GUI;
using Controller;
using System.IO;

namespace View
{

    /// <summary>
    /// Class to load options prefabs and control buttons animations
    /// </summary>
    public class OptionsMenu : MonoBehaviour
    {
        [Space]
        [Header("Animation")]
        /// <summary>
        /// The duration of the expand animation
        /// </summary>
        [SerializeField] private float ExpandDuration;
        /// <summary>
        /// The duration of the collapse animation
        /// </summary>
        [SerializeField] private float CollapseDuration;
        /// <summary>
        /// The expand animation
        /// </summary>
        [SerializeField] private Ease ExpandEase;
        /// <summary>
        /// The collapse animation
        /// </summary>
        [SerializeField] private Ease CollapseEase;

        [Space]
        [Header("Fading")]
        /// <summary>
        /// The expand duration of item fading
        /// </summary>
        [SerializeField] private float ExpandFadeDuration;
        /// <summary>
        /// The collapse duration of item fading
        /// </summary>
        [SerializeField] private float CollapseFadeDuration;
        /// <summary>
        /// Button that contains the position in which the items will be collapsed
        /// </summary>
        private Button _hamburgerButton;
        /// <summary>
        /// Array of the items to animate
        /// </summary>
        private OptionsMenuItem[] _optionItems;
        /// <summary>
        /// Flag that indicates if the optionsa are collapsed or expanded
        /// </summary>
        private bool _isExpanded;
        /// <summary>
        /// Postion oin which the items will start
        /// </summary>
        private Vector2 _hamburgerButtonPosition;
        /// <summary>
        /// Amount of items to be animated
        /// </summary>
        private int _itemsCount;
        /// <summary>
        /// Positions of each one item in _optionItems
        /// </summary>
        private Vector2[] _itemsPositions;
        /// <summary>
        /// Stack that contains all the prefabs that was loaded
        /// </summary>
        private Stack<string> _loadedPrefabs;
        /// <summary>
        /// The name of the prefab that is actually displayed in the screen
        /// </summary>
        private string actualPrefabName;
        public void Start()
        {
            _loadedPrefabs = new Stack<string>();
            actualPrefabName = "";
            LoadPrefab(Constants.PathGraphNodeSelectionMenu, "GraphNodeSelectionMenu", "ProjectionLayout");
        }
        /// <summary>
        /// Method to load a prefab and assign his parent and instance name
        /// </summary>
        /// <param name="prefabPath">The text that indicates the prefabs path</param>
        /// <param name="instanceName">The name that instance prefab will have</param>
        /// <param name="unityParent">The parent in the unity tree of the prefab</param>
        public void LoadPrefab(string prefabPath, string instanceName, string unityParent)
        {
            DestroyActualPrefabInstance();
            GameObject firstPrefab = Resources.Load(prefabPath) as GameObject;
            GameObject firstPrefabInstantiate = Instantiate(firstPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            firstPrefabInstantiate.name = instanceName;
            actualPrefabName = instanceName;
            firstPrefabInstantiate.transform.parent = GameObject.Find(unityParent).transform;
            firstPrefabInstantiate.transform.SetAsFirstSibling();
            _loadedPrefabs.Push(prefabPath);
            InitializeComponents();
        }
        /// <summary>
        /// Method to show the options tittle to indicate the user in what options menu are using
        /// </summary>
        /// <param name="tittle">The text that will be displayed in the screen</param>
        public void ShowTittle(string tittle)
        {
            GameObject textTittle = GameObject.Find("CurrentActionTitle");
            textTittle.GetComponent<Text>().text = tittle;
            textTittle.GetComponent<Text>().DOFade(1f, 2).From(0f).OnComplete(() => textTittle.GetComponent<Text>().DOFade(0f, 4).From(1f));

        }
        /// <summary>
        /// Method to destroy the actual options prefab when a new one is loaded
        /// </summary>
        private void DestroyActualPrefabInstance()
        {
            if (!actualPrefabName.Equals(""))
            {
                GameObject prefab = GameObject.Find(actualPrefabName);
                //Destroy(prefab);
                prefab.SetActive(false);
            }
        }
        /// <summary>
        /// Method to get the positions, and menu item of the actual prefab buttons
        /// </summary>
        private void InitializeComponents()
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
            _hamburgerButton.transform.SetAsLastSibling();
            //save position of hamburguer position
            _hamburgerButtonPosition = _hamburgerButton.transform.position;
            ResetPositions();
        }
        /// <summary>
        /// Method to assign the initial options positions
        /// </summary>
        private void ResetPositions()
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                _optionItems[i].GetTransform().position = _hamburgerButtonPosition;
            }
        }

        /// <summary>
        /// Method that decides if the options have to expand or collapse depending on which one is showing
        /// </summary>
        public void ToggleMenu()
        {
            if (!_isExpanded)
            {
                for (int i = 0; i < _itemsCount; i++)
                {
                    ExpandOrCollapse(_optionItems[i], _itemsPositions[i], ExpandDuration, ExpandFadeDuration, ExpandEase, 0.7f, 0f);
                }
            }
            else
            {
                for (int i = 0; i < _itemsCount; i++)
                {
                    ExpandOrCollapse(_optionItems[i], _hamburgerButtonPosition, CollapseDuration, CollapseFadeDuration, CollapseEase, 0.0f, 0.7f);
                }
            }
            _isExpanded = !_isExpanded;
        }

        /// <summary>
        /// Method to do the expand or collapse animation depending on the parameters
        /// </summary>
        /// <param name="item">The item that will have the animation</param>
        /// <param name="position">The final position in which the item will be placed</param>
        /// <param name="duration">The duration of the animation</param>
        /// <param name="fadeDuration">The duration of item fading</param>
        /// <param name="easeAnimation">The animation that item will use</param>
        /// <param name="fadeOpacity">The final opacity that the item will have</param>
        /// <param name="fromFadeOpacity">The initial opacity that the item will have</param>
        private void ExpandOrCollapse(OptionsMenuItem item, Vector2 position, float duration,
            float fadeDuration, Ease easeAnimation, float fadeOpacity, float fromFadeOpacity)
        {
            item.GetTransform().DOMove(position, duration).SetEase(easeAnimation);
            item.GetImage().DOFade(fadeOpacity, fadeDuration).From(fromFadeOpacity);
        }

    }
}