using System.Data.SqlClient;

namespace AnimalsAPI.Utils;

public class SqlUtils<TEntity>: IDatabaseUtils<TEntity>
{
    private readonly string _connectionString;
    public SqlUtils(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default") ??
                                throw new InvalidOperationException("Please verify if ConnectionStrings.Default is set");
    }

    public IEnumerable<TEntity> Read(SqlCommand command)
    {
        using var conn = new SqlConnection(_connectionString);

        command.Connection = conn;
        conn.Open();

        var data = new List<TEntity>();
        
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            
            
        }
    }

    public int Write(SqlCommand command)
    {
        throw new NotImplementedException();
    }
}