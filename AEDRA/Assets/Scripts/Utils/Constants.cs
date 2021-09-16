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
        public const string PrefabPath = "Prefabs/ProjectedObjects/";
        public const string MenusParentName = "ProjectionLayout";

        #region UNITY NAMES
        public const string NodeName = "Node_";
        public const string EdgeName = "Edge_";
        #endregion
        #region PATHS
        public static string DataPath = Utilities.GetDataPath();
        public static string ConstantsFilePath = Utilities.GetDataPath() + "Constants.json";
        #endregion
        public const int MaxWidth = 10;
        public const int MaxHeight = 10;
        public const int MaxDepth = 0;

        #region Pyshics
        public const float VerticalNodeTreeDistance = 2f;
        public const float HorizontalChildToParentDistance = 1.5f;
        public const float HorizontalForce = 5f;
        public const float MinimalHorizontalForce = 1f;
        public const float MinimalNodeDistance = 2f;
        #endregion
    }
}