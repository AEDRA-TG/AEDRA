using System.Collections;
using System.Collections.Generic;
using Model.Common;
using Repository;
using UnityEditor;
using UnityEngine;
using Utils;
using View.GUI;

namespace Controller
{
    public class SaveCommand : Command
    {
        public override void Execute()
        {
            CommandController.GetInstance().Repository.Save();
        }
    }
}