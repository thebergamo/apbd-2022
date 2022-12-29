using System.Data;
using UniversityAPI.DTOs;
using UniversityAPI.Exceptions;
using UniversityAPI.Models;

namespace UniversityAPI.Services;

public class StudentsService
{
    private DatabaseService _dbService;

    public StudentsService(DatabaseService dbService)
    {
        _dbService = dbService;
    }

    public List<Student> List()
    {
        return _dbService.List();
    }

    public Student Get(string indexNumber)
    {
        return _dbService.Get(indexNumber) ?? throw new RecordNotFoundException(indexNumber);
    }

    public StudentDTO Create(StudentDTO record)
    {
        var student = StudentDTO.ToEntity(record);

        // Possible Duplication record === Conflict https://stackoverflow.com/a/70371989/1666756
        if (_dbService.GetIndex(student.IndexNumber) != -1)
        {
            throw new DuplicateNameException("IndexNumber already exist in the records. Please verify your data");
        }
        
        _dbService.Create(student);

        return record;
    }
    
    public StudentDTO Update(string indexNumber, StudentDTO record)
    {
        if (_dbService.GetIndex(indexNumber) == -1)
        {
            throw new RecordNotFoundException(indexNumber);
        }
        
        var student = StudentDTO.ToEntity(record);

        if (indexNumber != student.IndexNumber)
        {
            throw new ArgumentException("Provided identifier of the request does not match one available in body.");
        }
        
        _dbService.Update(student);
        
        return record;
    }

    public void Delete(string indexNumber)
    {
        if (_dbService.GetIndex(indexNumber) == -1)
        {
            throw new RecordNotFoundException(indexNumber);
        }
        
        _dbService.Delete(indexNumber);
    }
}