using Utils.Enums;

namespace Repository
{
    /// <summary>
    /// Class to manage the data structures repositories
    /// </summary>
    public static class RepositoryFactory
    {
        public static DataStructureRepository CreateRepository(StructureEnum dataStructureName)
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