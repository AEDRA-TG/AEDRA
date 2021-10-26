using System.Collections.Generic;
using SideCar.DTOs;
using UnityEngine;
using Utils;
using Utils.Enums;

namespace Model.Common
{
    public class AlgorithmSteps : MonoBehaviour {
        private List<Step> _steps;
        [SerializeField] private AlgorithmStepsEnum StepsFile;  
        private void Awake(){
            _steps = Utilities.DeserializeJSON<List<Step>>(Constants.DataPath + StepsFile.ToString() + ".json");
        }

        public string GetStepDescription(int stepId, ElementDTO dto){
            foreach(Step step in _steps){
                if(step.Id == stepId){
                    return GetDescriptionWithValues(step, dto);
                }
            }
            return "";
        }

        public string GetDescriptionWithValues(Step step, ElementDTO dto){
            string descriptionWithValues = step.Description;
            foreach(string parameter in step.Parameters){
                switch(parameter){
                    case "<Node_Value>":
                        descriptionWithValues = descriptionWithValues.Replace(parameter, dto.Value.ToString());
                        break;
                }
            }
            return descriptionWithValues;
        }
    }
}