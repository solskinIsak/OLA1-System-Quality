using System.Data.SQLite;

namespace OLA1_SofQuality;

public class ToDoListService
{
    private ToDoList _toDoList = new ToDoList();
    private string _connectionString = "Data Source=C:\\Users\\marku\\Documents\\SOFTWARE BACHELOR\\1st Semester\\System Quality\\OLA1\\OLA1-SofQuality\\Data\\OlaDB.sqlite;Version=3;";
    //private string _connectionString = "Data Source=C:\\Users\\jcall\\Desktop\\testfag\\OLA1-System-Quality\\Data\\OlaDB.sqlite;Version=3;";
    //private string _connectionString = ">INDSÆT-ABSOLUTE-PATH-HELENA<;Version=3;";

    public void AddTask(Task task)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var command = new SQLiteCommand("INSERT INTO Tasks (Description, Category, Deadline, IsCompleted) VALUES (@Description, @Category, @Deadline, @IsCompleted)", connection);
            command.Parameters.AddWithValue("@Description", task.Description);
            command.Parameters.AddWithValue("@Category", task.Category);
            command.Parameters.AddWithValue("@Deadline", task.Deadline);
            command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
            command.ExecuteNonQuery();
        }
        _toDoList.AddTask(task);
    }

    public void UpdateTask(int id, Task updatedTask)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var command = new SQLiteCommand("UPDATE Tasks SET Description = @Description, Category = @Category, Deadline = @Deadline, IsCompleted = @IsCompleted WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Description", updatedTask.Description);
            command.Parameters.AddWithValue("@Category", updatedTask.Category);
            command.Parameters.AddWithValue("@Deadline", updatedTask.Deadline);
            command.Parameters.AddWithValue("@IsCompleted", updatedTask.IsCompleted);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
        _toDoList.UpdateTask(id, updatedTask);
    }

    public void DeleteTask(int id)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var command = new SQLiteCommand("DELETE FROM Tasks WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
        _toDoList.DeleteTask(id);
    }

    public void MarkTaskAsCompleted(int id)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var command = new SQLiteCommand("UPDATE Tasks SET IsCompleted = 1 WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
        _toDoList.MarkTaskAsCompleted(id);
    }

    public List<Task> GetTasks()
    {
        var tasks = new List<Task>();
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM Tasks", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var task = new Task
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        Category = reader.GetString(2),
                        Deadline = reader.GetDateTime(3),
                        IsCompleted = reader.GetBoolean(4)
                    };
                    tasks.Add(task);
                }
            }
        }
        return tasks;
    }

    // Method for unit testing without writing to SQLite database
    public void AddTaskForTesting(Task task)
    {
        _toDoList.AddTask(task);
    }
}