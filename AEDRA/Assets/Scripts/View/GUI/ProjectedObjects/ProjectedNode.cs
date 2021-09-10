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
            if(base.Dto != null){
                base.Dto.Coordinates.X = transform.parent.localPosition.x;
                base.Dto.Coordinates.Y = transform.parent.localPosition.y;
                base.Dto.Coordinates.Z = transform.parent.localPosition.z;
            }
        }

        public override Tween CreateAnimation(){
            return gameObject.transform.DOScale(1,base.AnimationTime);
        }

        public override Tween DeleteAnimation(){
            return gameObject.transform.DOScale(new Vector3(0,0,0),base.AnimationTime);
        }

        public override Tween PaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
            return mesh.material.DOColor(Color.cyan,base.AnimationTime).OnComplete( () => mesh.material.DOColor(Color.white, base.AnimationTime) );
        }

        public override Tween KeepPaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
            return mesh.material.DOColor(Color.cyan,base.AnimationTime);
        }
        
        public override Tween UnPaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
            return mesh.material.DOColor(Color.white,0);
        }

        public override void Move(Vector3 coordinates){
            gameObject.transform.parent.localPosition = coordinates;
        }

        public static ProjectedNode FindById(int id){
            return GameObject.Find(Constants.NodeName + id).GetComponent<ProjectedNode>();
        }
    }
}