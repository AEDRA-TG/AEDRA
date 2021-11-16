
using UnityEngine;
using Utils.Enums;

namespace Utils.Parameters
{
    /// <summary>
    /// Class that containt information for some menu
    /// </summary>
    public class MenuEnumParameter : MonoBehaviour{

        /// <summary>
        /// Menu name
        /// </summary>
        [SerializeField] private MenuEnum _menu;

        public void SetMenu(MenuEnum menu){
            _menu = menu;
        }

        public MenuEnum GetMenu(){
            return _menu;
        }
    }
}