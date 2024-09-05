namespace OLA1_SofQuality;

public class UnitTests
{

    [Fact]
    public void AddTask_ValidDescription_TaskIsCreated()
    {
        var dateTomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        var input = new StringReader("description\r\ncategory\r\n" + dateTomorrow);
        var originalInput = Console.In;
        Console.SetIn(input);

        try
        {
            Task task = Program.AddTask();
            Assert.Equal("description", task.Description);
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }

    [Fact]
    public void AddTask_ValidCategory_TaskIsCreated()
    {
        var dateTomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        var input = new StringReader("description\r\ncategory\r\n" + dateTomorrow);
        var originalInput = Console.In;
        Console.SetIn(input);

        try
        {
            Task task = Program.AddTask();
            Assert.Equal("category", task.Category);
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }

    [Fact]
    public void AddTask_ValidDeadline_TaskIsCreated()
    {
        var dateTomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        var input = new StringReader("description\r\ncategory\r\n" + dateTomorrow);
        var originalInput = Console.In;
        Console.SetIn(input);

        try
        {
            Task task = Program.AddTask();
            Assert.Equal(DateTime.Parse(dateTomorrow), task.Deadline);
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }

    [Fact]
    public void AddTask_InvalidDateInput_ThrowsFormatException()
    {
        var invalidDate = ("yyyy-MM-dd");
        var input = new StringReader("description\r\ncategory\r\n" + invalidDate);
        var originalInput = Console.In;
        Console.SetIn(input);

        try
        {
            Assert.Throws<FormatException>(() => Program.AddTask());
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }

    [Fact]
    public void AddTask_EmptyDescription_ThrowsArgumentException()
    {
        var dateTomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        var input = new StringReader("\r\ncategory\r\n" + dateTomorrow);
        var originalInput = Console.In;
        Console.SetIn(input);

        try
        {
            Assert.Throws<ArgumentException>(() => Program.AddTask());
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }

    [Fact]
    public void AddTask_EmptyCategory_ThrowsArgumentException()
    {
        var dateTomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        var input = new StringReader("description\r\r\n" + dateTomorrow);
        var originalInput = Console.In;
        Console.SetIn(input);

        try
        {
            Assert.Throws<ArgumentException>(() => Program.AddTask());
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }

    [Fact]
    public void AddTask_PastDeadline_ThrowsArgumentException()
    {
        var datePast = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        var input = new StringReader("description\r\ncategory\r\n" + datePast);  
        var originalInput = Console.In;
        Console.SetIn(input);

        try
        {
            Assert.Throws<ArgumentException>(() => Program.AddTask());
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }
}