using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace OLA1_SofQuality
{
    public class ToDoListService
    {
        private readonly SQLiteConnection _connection;
        private readonly string _tableName;

        public ToDoListService(SQLiteConnection connection, string tableName)
        {
            _connection = connection;
            _tableName = tableName;
        }

        public void AddTask(Task task)
        {
            using (var command = new SQLiteCommand(
                $"INSERT INTO {_tableName} (Description, Category, Deadline, IsCompleted) VALUES (@Description, @Category, @Deadline, @IsCompleted)", _connection))
            {
                command.Parameters.AddWithValue("@Description", task.Description);
                command.Parameters.AddWithValue("@Category", task.Category);
                command.Parameters.AddWithValue("@Deadline", task.Deadline.ToString("o"));
                command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted ? 1 : 0);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateTask(int id, Task updatedTask)
        {
            using (var command = new SQLiteCommand(
                $"UPDATE {_tableName} SET Description = @Description, Category = @Category, Deadline = @Deadline, IsCompleted = @IsCompleted WHERE Id = @Id", _connection))
            {
                command.Parameters.AddWithValue("@Description", updatedTask.Description);
                command.Parameters.AddWithValue("@Category", updatedTask.Category);
                command.Parameters.AddWithValue("@Deadline", updatedTask.Deadline.ToString("o"));
                command.Parameters.AddWithValue("@IsCompleted", updatedTask.IsCompleted ? 1 : 0);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int id)
        {
            using (var command = new SQLiteCommand($"DELETE FROM {_tableName} WHERE Id = @Id", _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void MarkTaskAsCompleted(int id)
        {
            using (var command = new SQLiteCommand($"UPDATE {_tableName} SET IsCompleted = 1 WHERE Id = @Id", _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public List<Task> GetTasks()
        {
            var tasks = new List<Task>();
            using (var command = new SQLiteCommand($"SELECT * FROM {_tableName}", _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var task = new Task
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            Category = reader.GetString(2),
                            Deadline = DateTime.Parse(reader.GetString(3)),
                            IsCompleted = reader.GetInt32(4) == 1
                        };
                        tasks.Add(task);
                    }
                }
            }
            return tasks;
        }
    }
}