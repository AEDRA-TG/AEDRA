using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public interface ICommand
    {
        public void Execute();
    }
}