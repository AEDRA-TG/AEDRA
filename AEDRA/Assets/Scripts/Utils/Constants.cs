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
        public const string PathHamburgerPrefab = "Prefabs/HamburgerMenu";
        public const string PathLargeButton = "Prefabs/LargeButton";
        //TODO: MAAAAL
        public const string PathMainTreeOptions = "Prefabs/MainTreeOptions";
        public const string PathRoundButton = "Prefabs/RoundButton";
        public const string PathThemeChooser = "Prefabs/ThemeChooser";
        public const string PathTraversalOptions = "Prefabs/TreeTraversalOptions";
        public const string PathGraphMainMenu = "Prefabs/GraphMainMenu";
        public const string PathGraphNode = "Prefabs/GraphNode";
        public const string PathGraphNodeSelectionMenu = "Prefabs/GraphNodeSelectionMenu";
        public const string ObjectsParentName = "StructureProjection";
        public const string PrefabPath = "Prefabs/";
        public const string GraphNodeSelectionMenu = "GraphNodeSelectionMenu";
        //
        public const string GraphFile = "Assets/Files/Graph.json";
    }
}