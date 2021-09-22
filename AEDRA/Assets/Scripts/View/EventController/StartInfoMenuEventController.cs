using UnityEngine;

namespace View.EventController
{
    public class StartInfoMenuEventController: AppEventController
    {
        private void Start() {
        }
        /// <summary>
        /// Hide Start Information Menu prefab
        /// </summary>
        private void HidePrefab() {
            this.gameObject.SetActive(false);
        }
    }
}