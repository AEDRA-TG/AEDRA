
using Vuforia;

namespace View.EventController
{
    using UnityEngine;
    public class ProjectionSceneController : MonoBehaviour {
        public void Start() {
#if UNITY_ANDROID
            VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
#endif
            
        }
    }
}