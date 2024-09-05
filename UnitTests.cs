namespace OLA1_SofQuality;

public class UnitTests
{
    
    [Fact]
    public void AddTask_ValidInputs_TaskIsCreated()
    {
        //  Arrange
        var input = new StringReader("description\rcategory\r2022-01-01");
        Console.SetIn(input);

        //  Act
        Task task = Program.AddTask(); 
        
        //  Assert
        Assert.Equal("description", task.Description);
        Assert.Equal("category", task.Category);
        Assert.Equal(DateTime.Parse("2022-01-01"), task.Deadline);
        
    }
}