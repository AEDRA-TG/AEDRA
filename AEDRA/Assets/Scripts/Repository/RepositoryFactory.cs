using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Repository
{
    public static class RepositoryFactory
    {
        public static IDataStructureRepository CreateRepository(string dataStructureName)
        {
            return dataStructureName switch
            {
                "Graph" => new GraphRepository(dataStructureName),
                _ => null,
            };
        }
    }
}