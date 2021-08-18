using UnityEngine;
using UnityEngine.UI;

namespace View
{

    /// <summary>
    /// Class of the item that could be animated
    /// </summary>
    public class OptionsMenuItem : MonoBehaviour
    {
        /// <summary>
        /// Image or background of the item
        /// </summary>
        [HideInInspector] private Image Img;
        /// <summary>
        /// Tranform property of the item
        /// </summary>
        [HideInInspector] private Transform Trans;

        public void Awake()
        {
            Img = GetComponent<Image>();
            Trans = transform;
        }

        //GETTERS Y SETTERS
        public void SetImg(Image img)
        {
            this.Img = img;
        }

        public Image GetImage()
        {
            return this.Img;
        }

        public void SetTranform(Transform trans)
        {
            this.Trans = trans;
        }

        public Transform GetTransform()
        {
            return this.Trans;
        }
    }
}