using System.Collections;
using System.Collections.Generic;
using Model.Common;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Vuforia;

namespace View.EventController
{
    public class TargetEventController : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private GameObject targetItemPrefab;
        public void Start()
        {
            List<Target> targets = Utilities.DeserializeJSON<List<Target>>(Constants.TargetsFilePath);
            foreach (Target target in targets)
            {
                Transform parent = GameObject.Find(Constants.TargetListParent).transform;
                GameObject item = Instantiate(targetItemPrefab, Vector3.zero, Quaternion.identity, parent);
                item.transform.localPosition = Vector3.zero;
                item.GetComponentInChildren<Text>().text = target.Name;
            }
        }

    }
}