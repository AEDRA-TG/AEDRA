using System.Collections.Generic;

namespace SideCar.Converters
{
    public abstract class AbstractConverter<E,D>
    {

        public abstract E ToEntity(D dto);

        public abstract D ToDto(E entity);

        public List<E> ToEntity(List<D> dtos)
        {
            if (dtos == null) return null;
            return dtos.ConvertAll(ToEntity);
        }

        public List<D> ToDto(List<E> entities)
        {
            if (entities == null) return null;
            return entities.ConvertAll(ToDto);
        }
    }
}