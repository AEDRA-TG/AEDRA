using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public interface IDataStructure
    {
        public void AddElement(object element);
        public void DeleteElement(object element);
        public void DoTraversal(string traversalName);
    }
}