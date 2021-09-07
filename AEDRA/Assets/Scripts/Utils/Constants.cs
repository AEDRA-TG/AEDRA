using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils
{

    /// <summary>
    /// Class that contains the global constans and configuration atributes
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Global color of all buttons in the app
        /// </summary>
        public static Color GlobalColor = Utilities.LoadGlobalColor();
        public const float AnimationTime = 1;
        public const string ObjectsParentName = "StructureProjection";
        public const string PrefabPath = "Prefabs/";
        public const string GraphFile = "Assets/Files/Graph.json";

        #region UNITY NAMES
        public const string NodeName = "Node_";
        public const string EdgeName = "Edge_";
        #endregion

        #region BUTTONS PREFABS
        
        public const string PathMainTreeOptions = "Prefabs/MainTreeOptions";
        public const string GraphNodeMultiSelectionMenu = "GraphNodeMultiSelectionMenu";
        public const string GraphTraversalMenu = "GraphTraversalMenu";
        public const string PathRoundButton = "Prefabs/RoundButton";
        public const string PathThemeChooser = "Prefabs/ThemeChooser";
        public const string PathTraversalOptions = "Prefabs/TreeTraversalOptions";
        public const string PathGraphMainMenu = "Prefabs/GraphMainMenu";
        public const string PathGraphNodeSelectionMenu = "Prefabs/GraphNodeSelectionMenu";
        public const string PathHamburgerPrefab = "Prefabs/HamburgerMenu";
        public const string PathLargeButton = "Prefabs/LargeButton";
        public const string GraphNodeSelectionMenu = "GraphNodeSelectionMenu";
        public const string TreeMainMenu = "TreeMainMenu";

        //
        #endregion
        public const string DataStructureFilePath = "Assets/Files/";
        public const int MaxWidth = 10;
        public const int MaxHeight = 10;
        public const int MaxDepth = 0;

        #region Pyshics
        public const float OjectPhysicsRepulsionDistance = 0.8f;
        public const float ObjectPhysicsRepulsionForce = 5f;
        public const float VerticalNodeTreeDistance = 2f;
        public const float HorizontalChildToParentDistance = 1f;
        public const float ObjectPhysicsRepulsionHorizontalDistance = 1.5f;
        #endregion
    }
}