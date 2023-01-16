using LinqTutorials.Models;

namespace LinqTutorials.Tests;

public class LinqTasks 
{
    // No strict test to the values as it out be too much trouble in this case
    // These tests are just high level
    [Fact]
    public void Task1_ReturnsOnlyBackendDevs()
    {
        var expectedTotalEmps = 2;

        var actual = LinqTutorials.LinqTasks.Task1().Count();
        
        Assert.Equal(expectedTotalEmps, actual);
    }
    
    [Fact]
    public void Task2_ReturnsOnlyFrontendDevs_AndSalaryBiggerThan1000_OrderedByName()
    {
        var expectedTotalEmps = 3;

        var actual = LinqTutorials.LinqTasks.Task2().Count();
        
        Assert.Equal(expectedTotalEmps, actual);

    }
    
    [Fact]
    public void Task3_ReturnBiggerSalaryAmongEmps()
    {
        var expectedSalary = 12000;

        var actual = LinqTutorials.LinqTasks.Task3();
        
        Assert.Equal(expectedSalary, actual);
    }
    
    [Fact]
    public void Task4_ReturnEmpsWithMaxSalary()
    {
        var expectedEmpsCount = 1;

        var actual = LinqTutorials.LinqTasks.Task4().Count();
        
        Assert.Equal(expectedEmpsCount, actual);
    }
    
    [Fact]
    public void Task5_ReturnEmpsWithNazwiskoAndPraca()
    {
        var actual = LinqTutorials.LinqTasks.Task5()
            .First()
            .GetType()
            .GetProperties();

        Assert.Equal(actual.Count(), 2);
        Assert.Equal("Nazwisko", actual[0].Name );
        Assert.Equal("Praca", actual[1].Name );
    }
    
    [Fact]
    public void Task6_ReturnEmpsWithDeps()
    {
        var actual = LinqTutorials.LinqTasks.Task6()
            .First()
            .GetType()
            .GetProperties();

        Assert.Equal(actual.Count(), 3);
        Assert.Equal("Ename", actual[0].Name );
        Assert.Equal("Job", actual[1].Name );
        Assert.Equal("Dname", actual[2].Name );
    }
    
    [Fact]
    public void Task7_ReturnCountOfJobs()
    {
        var expectedTotalJobTypes = 7;
        var actual = LinqTutorials.LinqTasks.Task7().Count();

        Assert.Equal(expectedTotalJobTypes, actual);
    }
    
    [Fact]
    public void Task8_ReturnTrueAsBackendDevsAreHired()
    {
        var expected = true;
        var actual = LinqTutorials.LinqTasks.Task8();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Task9_ReturnLatestHiredFrontend()
    {
        var expectedName = "Paweł Latowski";
        var actual = LinqTutorials.LinqTasks.Task9().Ename;
        
        Assert.Equal(expectedName, actual);
    }

    [Fact]
    public void Task10_ReturnEmpsWithBlankLine()
    {
        var expectedNewCount = 11;
        var actual = LinqTutorials.LinqTasks.Task10().Count();
        
        Assert.Equal(expectedNewCount, actual);
    }

    [Fact]
    public void Task11_ReturnDeptsWithEmpAndCount()
    {
        var expectedDeptCount = 2;
        var actual = LinqTutorials.LinqTasks.Task11().Count();

        Assert.Equal(expectedDeptCount, actual);
    }

    [Fact]
    public void Task12_ReturnEmpsWithSubordinates()
    {
        var expectedManagersCount = 2;
        var actual = LinqTutorials.LinqTasks.Task12().Count();

        Assert.Equal(expectedManagersCount, actual);
    }

    [Fact]
    public void Task13_ReturnOddNumber()
    {
        var input = new[] { 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1 };
        
        var expected = 10;

        var actual = LinqTutorials.LinqTasks.Task13(input);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Task14_ReturnDeptsWith0Or5Employees()
    {
        var expected = 1;
        var actual = LinqTutorials.LinqTasks.Task14().Count();
        
        Assert.Equal(expected, actual);
    }
}