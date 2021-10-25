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
        private Vector3? _startPosition;
        private Vector3? _endPosition;
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
            return gameObject.transform.DOScale(UpdateEdge(),base.AnimationTime).OnComplete(() => base.IsCreated = true);
        }

        /// <summary>
        /// Method that indicates if the edge enter in collision with other object
        /// </summary>
        /// <param name="other">The object that collision with edge</param>
        public void OnCollisionEnter(Collision other) {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), other.collider);
        }

        /// <summary>
        /// Method to actualize the edge position and size if their nodes moved
        /// </summary>
        /// <returns>Actualized edge scale</returns>
        private Vector3 UpdateEdge(){
            EdgeDTO edgeDTO = (EdgeDTO) base.Dto;
            Transform startPosition = GetNodeCoordinates(edgeDTO.IdStartNode);
            Transform endPosition = GetNodeCoordinates(edgeDTO.IdEndNode);
            const float width = 0.2f;
            Vector3 offset = endPosition.position - startPosition.position;
            Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
            gameObject.transform.position = startPosition.position + (offset / 2.0f);
            gameObject.transform.up = offset;

            if(_startPosition == null){
                base.text.transform.position = this.transform.position;
            } else if ( Vector2.Distance(startPosition.localPosition, (Vector3)_startPosition) != 0
                || Vector3.Distance(endPosition.localPosition, (Vector3)_endPosition) != 0 ){
                    base.text.transform.position = this.transform.position;
            }
            _startPosition = startPosition.localPosition;
            _endPosition = endPosition.localPosition;

            return scale;
        }

        /// <summary>
        /// Method to get a projected node coordinates
        /// </summary>
        /// <param name="id">Id to identify the node</param>
        /// <returns>The coordinates of the found node</returns>
        private Transform GetNodeCoordinates(int id){
            GameObject nodeFound = GameObject.Find(Constants.NodeName+ id);
            return nodeFound.transform;
        }

        public override Tween DeleteAnimation(){
            return gameObject.transform.DOScale(new Vector3(0,0,0),base.AnimationTime);
        }

        public override Tween PaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            return mesh.material.DOColor(Constants.VisitedObjectColor,base.AnimationTime).OnComplete( () => mesh.material.DOColor(Color.white, base.AnimationTime) );
        }
        public override Tween KeepPaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            return mesh.material.DOColor(Constants.VisitedObjectColor,base.AnimationTime);
        }

        public override Tween UnPaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            return mesh.material.DOColor(Constants.VisitedObjectColor,base.AnimationTime);
        }

        public override void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }
    }
}