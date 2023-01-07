using System.Data.SqlClient;

namespace AnimalsAPI.Services;

public interface ICrudService<TEntity, TBaseEntity, TEnumColumns>
{
    IEnumerable<TEntity> List(TEnumColumns parameters);
    TEntity Get(int id);
    TEntity Create(TBaseEntity entity);
    TEntity Update(int id, TEntity entity);
    void Delete(int id);

}