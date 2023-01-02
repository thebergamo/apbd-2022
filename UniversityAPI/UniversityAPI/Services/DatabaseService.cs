using System.Text;
using UniversityAPI.Exceptions;
using UniversityAPI.Models;
using UniversityAPI.Parsers;

namespace UniversityAPI.Services;

public class DatabaseService
{
    private readonly string dbPath = @"Data/students.csv";

    // INFO: This is a design choice of when the application startup I read the file from disk and keep it in memory.
    // This is due to simplicity and I don't expect file being updated externally.
    // In a closer to real life problem I would for sure cache the information to avoid I/O in every call but would keep
    // reading from disk from time to time or simply read it all the time using ASYNC methods.
    private List<Student> db;

    public DatabaseService()
    {
        db = CSVParser.Parse(dbPath);
    }

    public List<Student> List()
    {
        return db;
    }

    public int GetIndex(string indexNumber)
    {
        var index = db.FindIndex(student => student.IndexNumber == indexNumber);

        return index;
    }

    public Student? Get(string indexNumber)
    {
        var index = GetIndex(indexNumber);

        return index > -1 ? db[index] : null;
    }

    public void Create(Student newRecord)
    {
        db.Add(newRecord);
        Flush();
    }

    public void Update(Student record)
    {
        var index = GetIndex(record.IndexNumber);

        if (index == -1) return;
        
        db[index] = record;

        Flush();
    }

    public void Delete(string indexNumber)
    {
        var index = GetIndex(indexNumber);
        
        if (index == -1) return;

        db.RemoveAt(index);

        Flush();
    }

    private void Flush()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var record in db)
        {
            // just for simplicity
            sb.AppendLine(record.ToString());
        }

        File.WriteAllText(dbPath, sb.ToString());
    }
}