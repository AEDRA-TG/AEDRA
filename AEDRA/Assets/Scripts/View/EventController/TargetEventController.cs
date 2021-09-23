using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetEventController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        /*
        VuforiaBehaviour.Instance.ObserverFactory.

        StateManager sm = TrackerManager.Instance.GetStateManager();
        
        foreach (TrackableBehaviour tb in sm.)
        {
            if (tb is ImageTargetBehaviour)
            {
                ImageTargetBehaviour itb = tb as ImageTargetBehaviour;
                float dist2cam = (itb.transform.position - Camera.main.transform.position).magnitude;
                ImageTarget it = itb.Trackable as ImageTarget; Vector2 size = it.GetSize();
                GUI.Box(new Rect(50, 100, 300, 40), it.Name + " - " + size.ToString() + "\nDistance to camera: " + dist2cam);
            }
        }*/
    }
}
