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

        public void AddTask(SofQualityTask sofQualityTask)
        {
            using (var command = new SQLiteCommand(
                $"INSERT INTO {_tableName} (Description, Category, Deadline, IsCompleted) VALUES (@Description, @Category, @Deadline, @IsCompleted)", _connection))
            {
                command.Parameters.AddWithValue("@Description", sofQualityTask.Description);
                command.Parameters.AddWithValue("@Category", sofQualityTask.Category);
                command.Parameters.AddWithValue("@Deadline", sofQualityTask.Deadline.ToString("o"));
                command.Parameters.AddWithValue("@IsCompleted", sofQualityTask.IsCompleted ? 1 : 0);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateTask(int id, SofQualityTask updatedSofQualityTask)
        {
            using (var command = new SQLiteCommand(
                $"UPDATE {_tableName} SET Description = @Description, Category = @Category, Deadline = @Deadline, IsCompleted = @IsCompleted WHERE Id = @Id", _connection))
            {
                command.Parameters.AddWithValue("@Description", updatedSofQualityTask.Description);
                command.Parameters.AddWithValue("@Category", updatedSofQualityTask.Category);
                command.Parameters.AddWithValue("@Deadline", updatedSofQualityTask.Deadline.ToString("o"));
                command.Parameters.AddWithValue("@IsCompleted", updatedSofQualityTask.IsCompleted ? 1 : 0);
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

        public List<SofQualityTask> GetTasks()
        {
            var tasks = new List<SofQualityTask>();
            using (var command = new SQLiteCommand($"SELECT * FROM {_tableName}", _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var task = new SofQualityTask
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