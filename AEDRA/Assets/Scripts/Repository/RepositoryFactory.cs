using Utils.Enums;

namespace Repository
{
    /// <summary>
    /// Class to manage the data structures repositories
    /// </summary>
    public static class RepositoryFactory
    {
        /// <summary>
        /// Method to create the data structure asociated repository
        /// </summary>
        /// <param name="dataStructureName">Name of the data structure to create the repository</param>
        /// <returns>DataStructure repository if the data structure is supported, null otherwise</returns>
        public static DataStructureRepository CreateRepository(StructureEnum dataStructureName, string dataFile)
        {
            return dataStructureName switch
            {
                StructureEnum.Graph => new GraphRepository(dataFile),
                StructureEnum.BinarySearchTree => new BinarySearchTreeRepository(dataFile),
                _ => null,
            };
        }
    }
}