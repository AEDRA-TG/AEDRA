using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using SideCar.DTOs;

namespace View.GUI.ProjectedObjects
{
    public class ProjectedEdge : ProjectedObject
    {
        public void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            if(base.IsCreated){
                gameObject.transform.localScale = UpdateEdge();
            }
        }
        public override Tween CreateAnimation(){
            return gameObject.transform.DOScale(UpdateEdge(),base.AnimationTime);
        }

        private Vector3 UpdateEdge(){
            GraphEdgeDTO edgeDTO = (GraphEdgeDTO) base.Dto;
            Vector3 startPosition = GetNodeCoordinates(edgeDTO.IdStartNode);
            Vector3 endPosition = GetNodeCoordinates(edgeDTO.IdEndNode);

            const float width = 0.2f;
            Vector3 offset = endPosition - startPosition;
            Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
            gameObject.transform.parent.transform.localPosition = startPosition + (offset / 2.0f);
            gameObject.transform.parent.transform.up = offset;
            return scale;
        }

        private Vector3 GetNodeCoordinates(int id){
            GameObject nodeFound = GameObject.Find(Constants.NodeName+ id);
            return nodeFound.transform.localPosition;
        }
        public override Tween DeleteAnimation(){
            return gameObject.transform.parent.transform.DOScale(new Vector3(0,0,0),base.AnimationTime);
        }

        public override Tween PaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
            return mesh.material.DOColor(Color.cyan,base.AnimationTime).OnComplete( () => mesh.material.DOColor(Color.white, base.AnimationTime) );
        }

        public override void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }
    }
}