using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;

namespace View.GUI.ProjectedObjects
{
    public class ProjectedNode : ProjectedObject
    {
        // Start is called before the first frame update
        public void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {

        }

        public override Tween CreateAnimation(){
            return gameObject.transform.DOScale(1,Constants.AnimationTime);
        }

        public override Tween DeleteAnimation(){
            return gameObject.transform.DOScale(new Vector3(0,0,0),Constants.AnimationTime);
        }

        public override Tween PaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
            return mesh.material.DOColor(Color.red,Constants.AnimationTime);
        }

        public override void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }
    }
}