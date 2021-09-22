using UnityEngine;
using DG.Tweening;

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
        public const string HamburgerButtonName = "HamburgerMenu";
        #endregion
        #region PATHS
        public static string DataPath = Utilities.GetDataPath();
        public static string ConstantsFilePath = Utilities.GetDataPath() + "Constants.json";
        #endregion
        public const int MaxWidth = 10;
        public const int MaxHeight = 10;
        public const int MaxDepth = 0;

        #region PHYSICS
        public const float VerticalNodeTreeDistance = 2f;
        public const float HorizontalChildToParentDistance = 1.5f;
        public const float HorizontalForce = 5f;
        public const float MinimalHorizontalForce = 1f;
        public const float MinimalNodeDistance = 2f;
        #endregion

        #region MENU ANIMATIONS
        public const float ExpandDuration = 0.3f;
        /// <summary>
        /// The duration of the collapse animation
        /// </summary>
        public const float CollapseDuration  = 0.3f;
        /// <summary>
        /// The expand animation
        /// </summary>
        public const Ease ExpandEase = Ease.OutBack;
        /// <summary>
        /// The collapse animation
        /// </summary>
        public const Ease CollapseEase = Ease.InBack;
        /// <summary>
        /// The expand duration of item fading
        /// </summary>
        public const float ExpandFadeDuration = 0;
        /// <summary>
        /// The collapse duration of item fading
        /// </summary>
        public const float CollapseFadeDuration = 0;
        #endregion
    }
}