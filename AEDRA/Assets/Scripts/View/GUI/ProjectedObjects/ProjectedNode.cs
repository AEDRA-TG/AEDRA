using UnityEngine;
using DG.Tweening;
using Utils;
using SideCar.DTOs;
using Controller;

namespace View.GUI.ProjectedObjects
{
    /// <summary>
    /// Class to manage a projected node
    /// </summary>
    public class ProjectedNode : ProjectedObject
    {
        public void Start()
        {

        }

        public void Update()
        {
            gameObject.transform.rotation = Quaternion.identity;
            if(base.Dto != null){
                base.Dto.Coordinates.X = gameObject.transform.localPosition.x;
                base.Dto.Coordinates.Y = gameObject.transform.localPosition.y;
                base.Dto.Coordinates.Z = gameObject.transform.localPosition.z;
                Command command = new UpdateCommand(base.Dto);
                CommandController.GetInstance().Invoke(command);
            }

        }

        /// <summary>
        /// This method is used to control physics on an object
        /// </summary>
        public void FixedUpdate(){
            if(base.Dto is BinarySearchNodeDTO){
                base._objectPhysics.ApplyBinaryTreePhysics();
            }
            else{
                base._objectPhysics.ApplyGraphPhysics();
            }
            //TODO: Cambiar la forma en la que se identifica el tipo de nodo
        }


        public override Tween CreateAnimation(){
            return gameObject.transform.DOScale(1,base.AnimationTime).OnComplete( ()=> base.IsCreated = true);
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
            return mesh.material.DOColor(Color.white,0);
        }

        public override void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }
    }
}