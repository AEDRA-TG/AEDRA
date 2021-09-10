using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;

namespace Repository
{
    public static class RepositoryFactory
    {
        public static IDataStructureRepository CreateRepository(StructureEnum dataStructureName)
        {
            return dataStructureName switch
            {
                StructureEnum.Graph => new GraphRepository(dataStructureName),
                StructureEnum.BinarySearchTree => new BinarySearchTreeRepository(dataStructureName),
                _ => null,
            };
        }
    }
}