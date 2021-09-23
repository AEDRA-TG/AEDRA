using UnityEngine;
using DG.Tweening;
using Utils;
using SideCar.DTOs;

namespace View.GUI.ProjectedObjects
{
    /// <summary>
    /// Class to manage a projected edge
    /// </summary>
    public class ProjectedEdge : ProjectedObject
    {
        public void Start()
        {

        }

        public void Update()
        {
            Vector3 scale = UpdateEdge();
            if(base.IsCreated){
                gameObject.transform.localScale = scale;
            }
        }

        public override Tween CreateAnimation(){
            //TODO: make name of IsCreated more explitic (e.g: OnCreatedAnimationCompleted)
            return gameObject.transform.DOScale(UpdateEdge(),base.AnimationTime).OnComplete(()=> base.IsCreated = true);
        }

        public void OnCollisionEnter(Collision other) {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), other.collider);
        }
        private Vector3 UpdateEdge(){
            EdgeDTO edgeDTO = (EdgeDTO) base.Dto;
            Vector3 startPosition = GetNodeCoordinates(edgeDTO.IdStartNode);
            Vector3 endPosition = GetNodeCoordinates(edgeDTO.IdEndNode);
            const float width = 0.2f;
            Vector3 offset = endPosition - startPosition;
            Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
            gameObject.transform.position = startPosition + (offset / 2.0f);
            gameObject.transform.up = offset;
            return scale;
        }

        private Vector3 GetNodeCoordinates(int id){
            GameObject nodeFound = GameObject.Find(Constants.NodeName+ id);
            return nodeFound.transform.position;
        }

        public override Tween DeleteAnimation(){
            return gameObject.transform.DOScale(new Vector3(0,0,0),base.AnimationTime);
        }

        public override Tween PaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            return mesh.material.DOColor(Color.cyan,base.AnimationTime).OnComplete( () => mesh.material.DOColor(Color.white, base.AnimationTime) );
        }
        public override Tween KeepPaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            return mesh.material.DOColor(Color.cyan,base.AnimationTime);
        }

        public override Tween UnPaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            return mesh.material.DOColor(Color.white,base.AnimationTime);
        }

        public override void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }
    }
}