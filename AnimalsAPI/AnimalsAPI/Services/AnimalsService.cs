using System.Data.SqlClient;
using AnimalsAPI.DTOs;
using AnimalsAPI.Exceptions;

namespace AnimalsAPI.Services;

public enum AnimalSortableColumn
{
    Name,
    Description,
    Category,
    Area
}

public class AnimalsService: ICrudService<AnimalDto, BaseAnimalDto, AnimalSortableColumn>
{
    private readonly string _connectionString;
    
    public AnimalsService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default") ??
                            throw new InvalidOperationException("Please verify if ConnectionStrings.Default is set");
    }
    public IEnumerable<AnimalDto> List(AnimalSortableColumn orderBy)
    {
        using var connection = new SqlConnection(_connectionString);
        var LIST_QUERY =
            $"SELECT [IdAnimal], [Name], [Description], [Category], [Area] FROM Animal ORDER BY {orderBy} ASC;";

        var command = new SqlCommand(LIST_QUERY, connection);
        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        List<AnimalDto> response = new List<AnimalDto>();
        while (reader.Read())
        {
            response.Add(new AnimalDto(
                (int)reader["IdAnimal"],
                (string)reader["Name"],
                (string)reader["Description"],
                (string)reader["Category"],
                (string)reader["Area"]
            ));
        }

        return response;
    }
    public AnimalDto Get(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var GET_QUERY =
            @"SELECT
                [IdAnimal],
                [Name],
                [Description],
                [Category],
                [Area]
              FROM Animal
              WHERE [IdAnimal] = @IdAnimal;";

        var command = new SqlCommand(GET_QUERY, connection);
        command.Parameters.AddWithValue("@IdAnimal", id);
        
        connection.Open();

        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            throw new RecordNotFoundException(id);
        }
        
        return new AnimalDto(
            (int)reader["IdAnimal"],
            (string)reader["Name"],
            (string)reader["Description"],
            (string)reader["Category"],
            (string)reader["Area"]
        );
    }

    public AnimalDto Create(BaseAnimalDto entity)
    {
        using var connection = new SqlConnection(_connectionString);
        //INFO: return id of inserted object
        // https://stackoverflow.com/questions/1360453/how-do-i-insert-into-a-table-and-get-back-the-primary-key-value
        var INSERT_STMT = @"INSERT INTO
            Animal(Name, Description, Category, Area)
            VALUES (@Name, @Description, @Category, @Area);
            SELECT SCOPE_IDENTITY();";

        var command = new SqlCommand(INSERT_STMT, connection);
        command.Parameters.AddWithValue("@Name", entity.Name);
        command.Parameters.AddWithValue("@Description", entity.Description);
        command.Parameters.AddWithValue("@Category", entity.Category);
        command.Parameters.AddWithValue("@Area", entity.Area);
        
        connection.Open();

        var inserted = command.ExecuteScalar();

        return new AnimalDto(
            Convert.ToInt32(inserted),
            entity.Name,
            entity.Description,
            entity.Category,
            entity.Area
        );
    }

    public AnimalDto Update(int id, AnimalDto entity)
    {

        if (id != entity.IdAnimal)
        {
            throw new ArgumentException("Provided identifier of the request does not match one available in body.");
        }
        
        using var connection = new SqlConnection(_connectionString);
        var UPDATE_STMT = @"UPDATE Animal
            SET name = @Name,
                description = @Description,
                category = @Category,
                area = @Area
            WHERE idAnimal = @IdAnimal;
            SELECT @@ROWCOUNT;";

        var command = new SqlCommand(UPDATE_STMT, connection);
        command.Parameters.AddWithValue("@IdAnimal", id);
        command.Parameters.AddWithValue("@Name", entity.Name);
        command.Parameters.AddWithValue("@Description", entity.Description);
        command.Parameters.AddWithValue("@Category", entity.Category);
        command.Parameters.AddWithValue("@Area", entity.Area);
        
        connection.Open();

        var updated = command.ExecuteScalar();

        // INFO: Database itself verifies if record exists. If nothing is updated it means record doesn't exist
        if (Convert.ToInt32(updated) == 0)
        {
            throw new RecordNotFoundException(id);
        }

        return new AnimalDto(
            id,
            entity.Name,
            entity.Description,
            entity.Category,
            entity.Area
        );
    }

    public void Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var DELETE_STMT = @"DELETE FROM Animal
            WHERE idAnimal = @IdAnimal
            SELECT @@ROWCOUNT;";

        var command = new SqlCommand(DELETE_STMT, connection);
        command.Parameters.AddWithValue("@IdAnimal", id);
        
        connection.Open();

        var deleted = command.ExecuteScalar();

        // INFO: Database itself verifies if record exists. If nothing is deleted it means record doesn't exist
        if (Convert.ToInt32(deleted) == 0)
        {
            throw new RecordNotFoundException(id);
        }
    }
}