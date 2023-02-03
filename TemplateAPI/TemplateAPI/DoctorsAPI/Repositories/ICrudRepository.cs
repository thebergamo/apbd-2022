namespace DoctorsAPI.Repositories;

public interface ICrudRepository<TEntity>
{
    Task<IEnumerable<TEntity>> List();
    Task<TEntity> Get(int id);
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task Delete(int id);
}