using System.Collections;
using System.Collections.Generic;
using Model.Common;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Vuforia;
using System.IO;
using UnityEngine.Networking;

namespace View.EventController
{
    public class TargetEventController : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private GameObject targetItemPrefab;
        private List<Target> _targets;

        public void Awake(){
            _targets = Utilities.DeserializeJSON<List<Target>>(Constants.TargetsFilePath);
        }
        public void Start()
        {
            foreach (Target target in _targets)
            {
                Transform parent = GameObject.Find(Constants.TargetListContentName).transform;
                GameObject item = Instantiate(targetItemPrefab, Vector3.zero, Quaternion.identity, parent);
                item.transform.localPosition = Vector3.zero;
                item.GetComponentInChildren<Text>().text = target.Name;
                item.name= "Target_"+target.Name;
                item.GetComponent<Button>()?.onClick.AddListener(delegate() {OnTouchViewTargetDetails(target);});
            }
        }

        public void OnTouchViewTargetDetails(Target target){
            ToggleTargetsView(true);
            GameObject targetDetails = GameObject.Find(Constants.TargetDetailsName);
            GameObject title = GameObject.Find("Title");
            title.GetComponent<Text>().text = target.Name;
        }

        private void ToggleTargetsView(bool state){
            GameObject layout = GameObject.Find(Constants.TargetsLayoutName);
            GameObject targetList = layout.transform.Find(Constants.TargetListName).gameObject;
            GameObject targetDetails = layout.transform.Find(Constants.TargetDetailsName).gameObject;
            targetList.SetActive(!state);
            targetDetails.SetActive(state);
        }

        public void OnTouchBackToTargetList(){
            ToggleTargetsView(false);
        }

        public void OnTouchNextFace(){
            
        }

        public void OnTouchBackFace(){

        }

        public void OnTouchDownloadActualFace(){
            string targetFilePath = "/storage/emulated/0/Descargas/" + "target.txt";
            if(!File.Exists(Constants.TargetsFilePath)){
                #if UNITY_EDITOR
                string pathFile = "file://" + Constants.TargetStreamingFileBasePath + "target.txt";
                #elif UNITY_ANDROID
                string pathFile = Constants.TargetStreamingFileBasePath + "target.txt";
                #endif
                UnityWebRequest fileRequest = UnityWebRequest.Get(pathFile);
                fileRequest.SendWebRequest();
                while(!fileRequest.isDone){}
                File.WriteAllBytes(Constants.TargetsFilePath, fileRequest.downloadHandler.data);
            }
        }
    }
}