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
        /// This section contains file and prefab paths
        /// </summary>
        #region PATHS

        public static string DataPath = Application.persistentDataPath + "/";
        public static string ConstantsStreamingFilePath = Application.streamingAssetsPath + "/ConfigFiles/Variables.json";
        public static string ConstantsFilePath = Application.persistentDataPath + "/Variables.json";
        public static string TargetsStreamingFilePath = Application.streamingAssetsPath + "/ConfigFiles/Targets.json";
        public static string TargetsFilePath = Application.persistentDataPath + "/Targets.json";
        public static string TutorialsFilePath = Application.persistentDataPath + "/Tutorials.json";
        public static string TutorialsStreamingFilePath = Application.streamingAssetsPath + "/ConfigFiles/Tutorials.json";
        public const string PrefabPath = "Prefabs/ProjectedObjects/";
        //TODO: delete this
        public static string DijkstraFilePath = Application.persistentDataPath + "/Dijkstra.json";
        public static string DijkstraStreamingFilePath = Application.streamingAssetsPath + "/Algorithms/Dijkstra.json";
        public static string IconTargetResourcePath = "Icon/Targets/";
        public static string ImageTargetResourcePath = "Image/Targets/";
        public static string DownloadTargetFolder = "Marcadores_AEDRA";
        public static string IconResourceFolder = "Icon/";
        
        #endregion

        /// <summary>
        /// Default value for the animation duration
        /// </summary>
        public const float AnimationTime = 1;

        /// <summary>
        /// This section contains names used to identify view elements
        /// </summary>
        #region UNITY NAMES

        /// <summary>
        /// Parent of all 3D objects
        /// </summary>
        public const string ObjectsParentName = "StructureProjection";
        public const string NodeName = "Node_";
        public const string EdgeName = "Edge_";
        public const string HamburgerButtonName = "HamburgerMenu";
        public const string InfoButtonName = "InfoButton";
        public const string HelpButtonMenuName = "HelpButtonMenu";
        public const string TooltipName = "Tooltip";
        public const string MenusParentName = "ProjectionLayout";
        public const string ListContentName = "Content";
        public const string ReferencePointName = "ReferencePoint";
        public const string ChooserName = "Chooser";
        public const string ProjectionLayoutName = "ProjectionLayout";
        public const string NotificationName = "Notification";
        
        #endregion

        /// <summary>
        /// Targets screen gameobject names
        /// </summary>
        #region TARGETS GAMEOBJECTS NAMES

        public const string TargetListName = "TargetList";
        public const string TargetDetailsName = "TargetDetails";
        public const string TargetsLayoutName = "TargetsLayout";
        public const string BackOptionsMenuParent = "BackButton";
        public const string TargetsPopupMenuName = "PopupMenu";
        public const string TargetName = "Target_";
        public const string TargetItemIconName = "TargetIcon";
        public const string TargetDetailsBackFaceButton = "BackFaceButton";
        public const string TargetDetailsNextFaceButton = "NextFaceButton";
        public const string TargetDetailsDownloadTargetButton = "DownloadTargetButton";
        public const string FaceDetailsName = "FaceName";
        public const string FaceDetailsDescription ="FaceDescription";
        public const string FaceDetailsImage ="FaceImage";

        #endregion

        /// <summary>
        /// Tutorials screen gameobject names
        /// </summary>
        #region TUTORIALS GAMEOBJECT NAMES

        public const string TutorialListName = "TutorialList";
        public const string TutorialDetailsName = "TutorialDetails";
        public const string TutorialLayoutName = "TutorialsLayout";
        public const string TutorialName = "Tutorial_";
        public const string TutorialItemIconName = "TutorialIcon";
        public const string TitleName = "Title";
        public const string VideoControlName = "VideoControl";
        public const string IconPlayName = "IconPlay";
        public const string IconPauseName = "IconPause";
        public const string ReproductionButtonName = "ReproductionButton";

        #endregion

        #region COLORS
        /// <summary>
        /// Global color of all buttons in the app
        /// </summary>
        public static Color GlobalColor;
        public static Color SelectionColor = Color.red;
        public static Color BaseObjectColor = Color.white;
        public static Color VisitedObjectColor = Color.cyan;
        public static Color ValueFoundColor = Color.green;

        #endregion

        public const int MaxWidth = 10;
        public const int MaxHeight = 10;
        public const int MaxDepth = 0;

        #region PHYSICS

        public const float VerticalNodeTreeDistance = 2f;
        public const float HorizontalChildToParentDistance = 1.5f;
        public const float HorizontalForce = 5f;
        public const float MinimalHorizontalForce = 2f;
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

        #region UNITY TAGS
        public const string TagBackSubMenu = "BackSubMenu";

        #endregion
    }
}