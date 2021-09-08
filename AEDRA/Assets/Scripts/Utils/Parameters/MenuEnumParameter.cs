
using UnityEngine;
using Utils.Enums;

namespace Utils.Parameters
{
    public class MenuEnumParameter : MonoBehaviour{
        [SerializeField] private MenuEnum _menu;

        public void SetMenu(MenuEnum menu){
            _menu = menu;
        }

        public MenuEnum GetMenu(){
            return _menu;
        }
    }
}