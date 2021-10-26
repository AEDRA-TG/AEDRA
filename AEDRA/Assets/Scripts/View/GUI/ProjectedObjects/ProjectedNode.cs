using UnityEngine;
using DG.Tweening;
using Utils;
using SideCar.DTOs;
using Controller;
using Utils.Enums;
using TMPro;
using Model.Common;

namespace View.GUI.ProjectedObjects
{
    /// <summary>
    /// Class to manage a projected node
    /// </summary>
    public class ProjectedNode : ProjectedObject
    {
        private Vector3 _lastPosition;
        private bool _isMoving;
        private bool _isSaved;
        private float _timer;
        [SerializeField]
        private TextMesh _info;

        public void Start()
        {
            _lastPosition = Vector3.zero;
            _isSaved = false;
            _timer = 0.0f;
        }

        public void Update()
        {
            // Wait 0.5 seconds
            if(WaitTimeInterval(0.5f))
            {
                // If the node is not moving
                if(Vector3.Distance(_lastPosition,transform.localPosition)==0){
                    if(!_isSaved) {
                        // If it's not saved
                        if(base.Dto != null){
                            base.Dto.Coordinates.X = gameObject.transform.localPosition.x;
                            base.Dto.Coordinates.Y = gameObject.transform.localPosition.y;
                            base.Dto.Coordinates.Z = gameObject.transform.localPosition.z;
                            Command command = new UpdateCommand(base.Dto);
                            CommandController.GetInstance().Invoke(command);
                            _isSaved = true;
                        }
                    }
                }
                else{
                    _isSaved = false;
                    _lastPosition = transform.localPosition;
                }
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
            return mesh.material.DOColor(GetColorToUse(),base.AnimationTime).OnComplete( () => mesh.material.DOColor(Color.white, base.AnimationTime) );
        }

        public override Tween KeepPaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            return mesh.material.DOColor(GetColorToUse(),base.AnimationTime);
        }
        public override Tween UnPaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            return mesh.material.DOColor(GetColorToUse(),0);
        }
        public override void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }

        public bool WaitTimeInterval(float waitTime){
            _timer += Time.deltaTime;
            bool finished = false;
            if (_timer > waitTime)
            {
                _timer = 0;
                finished = true;
            }
            return finished;
        }

        public override Tween UpdateAnimation()
        {
            Tween tween = default;
            if(base.Dto.Info != null){
                string infoText = Dto.Info;
                tween = _info.transform.DOScale(0.02f, base.AnimationTime).OnStart(()=> _info.text = infoText);
            }
            return tween;
        }

        public override Tween StepInformationAnimation()
        {
            Tween tweenStep = default;
            if(base.Dto.Step != -1){
                Debug.Log("ASDASD");
                GameObject targetInformation = GameObject.Find(Constants.TargetInformationName);
                if(targetInformation != null){
                    Debug.Log("NOT NULL");
                    Transform information = targetInformation.transform.Find("Information");
                    TextMeshPro stepText = information.GetComponent<TextMeshPro>();
                    AlgorithmSteps algorithmSteps = targetInformation.GetComponent<AlgorithmSteps>();
                    tweenStep = information.DOScale(0.01245f, base.AnimationTime);
                    string stepDescription = algorithmSteps.GetStepDescription(Dto.Step, Dto);
                    tweenStep.OnUpdate(()=>stepText.text = stepDescription);
                }
            }
            return tweenStep;
        }
    }
}