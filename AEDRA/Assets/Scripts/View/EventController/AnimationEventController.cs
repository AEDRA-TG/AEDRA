using UnityEngine;
using DG.Tweening;
using View.Animations.Algorithms;
using System.Collections.Generic;
using View.GUI.ProjectedObjects;
using Controller;
using Utils.Enums;
using SideCar.DTOs;
using View.Animations;
using Utils;
using View.GUI;

namespace View.EventController
{
    public class AnimationEventController : MonoBehaviour
    {
        private Sequence _actualSequence;
        private int _animationDuration;
        private Command _command;
        public void OnEnable() {
            AlgorithmAnimation.UpdateSecuenceEvent += UpdateSequence;
            TraversalAnimation.UpdateSecuenceEvent += UpdateSequence;
        }

        public void OnDisable() {
            AlgorithmAnimation.UpdateSecuenceEvent -= UpdateSequence;
            TraversalAnimation.UpdateSecuenceEvent -= UpdateSequence;
        }

        public void OnTouchTogglePlayAnimation(){
            if(this._actualSequence == null){
                InvokeDijkstraCommand();
            }
            else{
                _actualSequence.TogglePause();
                if(!_actualSequence.IsPlaying()){
                    _actualSequence.Goto((int)_actualSequence.id*_animationDuration);
                }
            }
        }

        public void InvokeDijkstraCommand(){
            SelectionController _selectionController = FindObjectOfType<SelectionController>();
            List<ProjectedObject> objs = _selectionController.GetSelectedObjects();
            if (objs.Count == 2)
            {
                if(objs[0].GetType() == typeof(ProjectedNode) && objs[1].GetType() == typeof(ProjectedNode)){
                    this._command = new DoAlgorithmCommand(AlgorithmEnum.Dijkstra,new List<ElementDTO>(){objs[0].Dto, objs[1].Dto});
                    _selectionController.DeselectAllObjects();
                    CommandController.GetInstance().Invoke(this._command);
                }
            }
            else
            {
                StructureProjection structureProjection = FindObjectOfType<StructureProjection>(); 
                structureProjection.ShowNotification("Debes seleccionar 2 nodos para ver el algoritmo");
            }
        }

        public void OnTouchNextAnimation(){
            if(this._actualSequence != null){
                if((int)this._actualSequence.id < this._actualSequence.Duration()){
                    _actualSequence.id =  (int)_actualSequence.id+_animationDuration;
                    _actualSequence.Goto((int)_actualSequence.id*_animationDuration);
                }
            }
        }

        public void OnTouchPreviousAnimation(){
            if(this._actualSequence != null){
                if((int)this._actualSequence.id > 0){
                    _actualSequence.id =  (int)_actualSequence.id-_animationDuration;
                    _actualSequence.Goto((int)_actualSequence.id*_animationDuration);
                }
            }
            
        }

        public void UpdateSequence(Sequence newSequence){
            this._animationDuration = (int) Constants.AnimationTime;
            this._actualSequence = newSequence;
            this._actualSequence.id = (int)0;
            this._actualSequence.OnComplete(() => {
                this._actualSequence.id = (int)0;
                this._actualSequence.Goto((int)this._actualSequence.id);
                });
            GameObject playPauseGameObject = GameObject.Find("PlayStopButton");
            this._actualSequence.OnPause(()=>{
                playPauseGameObject.transform.Find("Icon").gameObject.SetActive(true);
                playPauseGameObject.transform.Find("IconPause").gameObject.SetActive(false);
            });
            this._actualSequence.OnPlay(()=> {
                playPauseGameObject.transform.Find("IconPause").gameObject.SetActive(true);
                playPauseGameObject.transform.Find("Icon").gameObject.SetActive(false);
            });
        }

        public void OnTouchExitAnimation(){
            this._actualSequence.Goto(0);
        }
    }
}