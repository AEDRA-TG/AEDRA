using System.Collections.Generic;

namespace SideCar.Converters
{
    public abstract class AbstractConverter<E,D>
    {
        /// <summary>
        /// Method to convert a DTO to the respective Entity
        /// </summary>
        /// <param name="dto">DTO to convert</param>
        /// <returns>Entity with the data given by the dto</returns>
        public abstract E ToEntity(D dto);

        /// <summary>
        /// Method to convert a entity to the respective DTO
        /// </summary>
        /// <param name="entity">Entity to convert</param>
        /// <returns>DTO with the data given by the entity</returns>
        public abstract D ToDto(E entity);
        /// <summary>
        /// Method to convert a list of DTOs to a List of Entities
        /// </summary>
        /// <param name="dtos">List of elements to convert</param>
        /// <returns>Converted list</returns>
        public List<E> ToEntity(List<D> dtos)
        {
            if (dtos == null) return null;
            return dtos.ConvertAll(ToEntity);
        }
        /// <summary>
        /// Method to convert a list of Entities to a List of DTOs
        /// </summary>
        /// <param name="entities">List of elements to convert</param>
        /// <returns>Converted list</returns>
        public List<D> ToDto(List<E> entities)
        {
            if (entities == null) return null;
            return entities.ConvertAll(ToDto);
        }
    }
}