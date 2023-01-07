namespace AnimalsAPI.Mappers;

public interface IMapper<TEntity, TDto>
{
    TDto From(TEntity entity);
    TEntity From(TDto dto);
}