using System.Collections;
using System.Collections.Generic;
using Model.Common;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace View.EventController
{
    public class TutorialEventController : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private GameObject tutorialItemPrefab;
        private List<Tutorial> _tutorials;
        private GameObject _layout;
        private GameObject _tutorialList;
        private GameObject _tutorialDetails;
        private UnityEngine.Video.VideoPlayer _videoPlayer;

        public void Awake(){
            _tutorials = Utilities.DeserializeJSON<List<Tutorial>>(Constants.TutorialsFilePath);
            _layout = GameObject.Find(Constants.TutorialLayoutName);
            _tutorialList = _layout.transform.Find(Constants.TutorialListName).gameObject;
            _tutorialDetails = _layout.transform.Find(Constants.TutorialDetailsName).gameObject;
            _videoPlayer = _tutorialDetails.GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
        }
        public void Start()
        {
            foreach (Tutorial tutorial in _tutorials){
                Transform parent = GameObject.Find(Constants.ListContentName).transform;
                GameObject item = Instantiate(tutorialItemPrefab, Vector3.zero, Quaternion.identity, parent);
                item.transform.localPosition = Vector3.zero;
                item.GetComponentInChildren<Text>().text = tutorial.Name;
                item.name= Constants.TutorialName+tutorial.Name;
                item.transform.Find(Constants.TutorialItemIconName).transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(Constants.IconResourceFolder + tutorial.ResourceIconName);
                item.GetComponent<Button>()?.onClick.AddListener(delegate() {OnTouchViewTutorialDetails(tutorial);});
            }
        }

        private void OnTouchViewTutorialDetails(Tutorial tutorial){
            ToggleTutorialView(true);
            GameObject title = GameObject.Find(Constants.TitleName);
            title.GetComponent<Text>().text = tutorial.Name;
            GameObject videoControl = GameObject.Find(Constants.VideoControlName);
            //videoControl.GetComponent<UnityEngine.Video.VideoPlayer>().url = tutorial.VideoURL;
        }

        private void ToggleTutorialView(bool state){
            _tutorialList.SetActive(!state);
            _tutorialDetails.SetActive(state);
        }

        public void OnTouchBackToTutorialList(){
            ToggleTutorialView(false);
        }

        public void OnTouchReproductionButton(){
            if(_videoPlayer.isPlaying){
                ToggleReproductionIcon(true);
                _videoPlayer.Pause();
            }
            else{
                ToggleReproductionIcon(false);
                _videoPlayer.Play();
            }
        }

        public void OnTouchRestartVideoButton(){
            _videoPlayer.Stop();
            ToggleReproductionIcon(true);
        }

        private void ToggleReproductionIcon(bool state){
            GameObject reproductionButton = GameObject.Find(Constants.ReproductionButtonName);
            reproductionButton.transform.Find(Constants.IconPlayName).gameObject.SetActive(state);
            reproductionButton.transform.Find(Constants.IconPauseName).gameObject.SetActive(!state);
        }
    }
}