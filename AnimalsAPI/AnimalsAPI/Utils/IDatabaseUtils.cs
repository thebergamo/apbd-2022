using System.Data.SqlClient;

namespace AnimalsAPI.Utils;

public interface IDatabaseUtils<TEntity>
{
    IEnumerable<TEntity> Read(SqlCommand command);
    int Write(SqlCommand command);
}