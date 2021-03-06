using System.Collections;
using System.Collections.Generic;
using Model.Common;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace View.EventController
{
    public class TargetEventController : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private GameObject targetItemPrefab;
        private List<Target> _targets;
        
        private GameObject _layout;
        private GameObject _targetList;
        private GameObject _targetDetails;
        private GameObject _popupMenu;
        [SerializeField]
        private GameObject closePopupMenu;
        [SerializeField]
        private GameObject doubleConfirmation;

        public void Awake(){
            _targets = Utilities.DeserializeJSON<List<Target>>(Constants.TargetsFilePath);
            _layout = GameObject.Find(Constants.TargetsLayoutName);
            _targetList = _layout.transform.Find(Constants.TargetListName).gameObject;
            _targetDetails = _layout.transform.Find(Constants.TargetDetailsName).gameObject;
            _popupMenu = _layout.transform.Find(Constants.TargetsPopupMenuName).gameObject;
        }
        public void Start()
        {
            foreach (Target target in _targets)
            {
                Transform parent = GameObject.Find(Constants.ListContentName).transform;
                GameObject item = Instantiate(targetItemPrefab, Vector3.zero, Quaternion.identity, parent);
                item.transform.localPosition = Vector3.zero;
                item.GetComponentInChildren<Text>().text = target.Name;
                item.name= Constants.TargetName+target.Name;
                item.transform.Find(Constants.TargetItemIconName).transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(Constants.IconTargetResourcePath + target.ResourceIconName);
                item.GetComponent<Button>()?.onClick.AddListener(delegate() {OnTouchViewTargetDetails(target);});
            }
        }

        private void OnTouchViewTargetDetails(Target target){
            ToggleTargetsView(true);
            GameObject title = GameObject.Find(Constants.TitleName);
            title.GetComponent<Text>().text = target.Name;
            ChangeFaceDetails(target.Faces[0]);
            GameObject backFace = GameObject.Find(Constants.TargetDetailsBackFaceButton);
            backFace.GetComponent<Button>().onClick.AddListener(delegate() {ChangeFaceDetails(target.Faces[0]);});
            GameObject nextFace  = GameObject.Find(Constants.TargetDetailsNextFaceButton);
            nextFace.GetComponent<Button>().onClick.AddListener(delegate() {ChangeFaceDetails(target.Faces[1]);});
            GameObject downloadTargetButton = GameObject.Find(Constants.TargetDetailsDownloadTargetButton);
            downloadTargetButton.GetComponent<Button>()?.onClick.AddListener(delegate() {OnTouchDownloadActualTarget(target);});
        }

        private void ChangeFaceDetails(Target target){
            GameObject faceName = GameObject.Find(Constants.FaceDetailsName);
            faceName.GetComponent<Text>().text = target.Name;
            GameObject faceImage = GameObject.Find(Constants.FaceDetailsImage);
            faceImage.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(Constants.ImageTargetResourcePath + target.ARMarker);
            GameObject faceDescription = GameObject.Find(Constants.FaceDetailsDescription);
            faceDescription.GetComponent<Text>().text = target.Description;
        }

        private void ToggleTargetsView(bool state){
            _targetList.SetActive(!state);
            _targetDetails.SetActive(state);
        }

        public void OnTouchBackToTargetList(){
            ToggleTargetsView(false);
        }

        private void OnTouchDownloadActualTarget(Target target){
            foreach(Target faceTarget in target.Faces){
                SaveTargetFace(target.Name, faceTarget);
            }
        }

        private void SaveTargetFace(string targetName,Target targetFace){
            _popupMenu.SetActive(true);
            StartCoroutine(SaveFiles(targetName, targetFace));
        }

        private IEnumerator SaveFiles(string targetName,Target targetFace){
            Texture2D face = Resources.Load<Texture2D>(Constants.ImageTargetResourcePath + targetFace.ARMarker);
            byte[] faceBytes = face.EncodeToPNG();
            NativeGallery.SaveImageToGallery(faceBytes, Constants.DownloadTargetFolder, targetName + "_" + targetFace.Name + ".png", null);
            yield return null;
            closePopupMenu.SetActive(true);
        }
        public void OnTouchDownloadAll(){
            this.doubleConfirmation.SetActive(true);
        }

        public void OnTouchConfirmDownload(){
            this.doubleConfirmation.SetActive(false);
            foreach(Target target in this._targets){
                OnTouchDownloadActualTarget(target);
            }
        }

        public void OnTouchCancelDownload(){
            this.doubleConfirmation.SetActive(false);
        }

        public void OnTouchClosePopupMenu(){
            _popupMenu.SetActive(false);
            closePopupMenu.SetActive(false);
        }
    }
}