using UnityEngine;
using Utils;

namespace View.EventController
{
    public class InformativeTargetController : MonoBehaviour {

        private GameObject _informationParent;
        private GameObject _actualSubMenu;
        private int _actualMenu;

        public void SetInformationParent(string informationParent){
            _informationParent = GameObject.Find(informationParent);
            _actualMenu = 1;
            _actualSubMenu = _informationParent.transform.Find(Constants.MenuName+_actualMenu).gameObject;
            _actualSubMenu.gameObject.SetActive(true);
        }
        
        public void OnTouchNextFaces(){
            if(_actualMenu <= _informationParent.transform.childCount ){
                _actualSubMenu.SetActive(false);
                _actualMenu++;
                if(_actualMenu > _informationParent.transform.childCount){
                    _actualMenu = 1;
                }
                _actualSubMenu = _informationParent.transform.Find(Constants.MenuName+_actualMenu).gameObject;
                _actualSubMenu.SetActive(true);
            }
        }

        public void DesactiveActualMenu(){
            _actualSubMenu.SetActive(false);
        }
    }
}