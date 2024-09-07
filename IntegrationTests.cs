using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading;
using Xunit;

namespace OLA1_SofQuality
{
    public class IntegrationTests : IDisposable
    {
        private readonly ToDoListService _toDoListService;
        private readonly SQLiteConnection _connection;

        public IntegrationTests()
        {
            var connectionString = "Data Source=:memory:;Version=3;New=True;";
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
            InitializeDatabase();
            _toDoListService = new ToDoListService(_connection, "TasksTest");
        }

        private void InitializeDatabase()
        {
            using (var command = new SQLiteCommand(
                       "CREATE TABLE IF NOT EXISTS TasksTest (" +
                       "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                       "Description TEXT NOT NULL, " +
                       "Category TEXT NOT NULL, " +
                       "Deadline DATETIME NOT NULL, " +
                       "IsCompleted BOOLEAN NOT NULL)", _connection))
            {
                command.ExecuteNonQuery();
            }
            // Log table creation
            using (var command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='TasksTest';", _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("Table 'TasksTest' created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create table 'TasksTest'.");
                    }
                }
            }
        }

        [Fact]
        public void AddTask_TaskIsAdded()
        {
            var task = new Task
            {
                Description = "Test Task",
                Category = "Test Category",
                Deadline = DateTime.Now.AddDays(1),
                IsCompleted = false
            };

            _toDoListService.AddTask(task);

            var tasks = _toDoListService.GetTasks();
            Assert.Single(tasks);
            Assert.Equal("Test Task", tasks[0].Description);
        }

        [Fact]
        public void UpdateTask_TaskIsUpdated()
        {
            var task = new Task
            {
                Description = "Test Task",
                Category = "Test Category",
                Deadline = DateTime.Now.AddDays(1),
                IsCompleted = false
            };

            _toDoListService.AddTask(task);
            var tasks = _toDoListService.GetTasks();
            var taskId = tasks[0].Id;

            var updatedTask = new Task
            {
                Description = "Updated Task",
                Category = "Updated Category",
                Deadline = DateTime.Now.AddDays(2),
                IsCompleted = true
            };

            _toDoListService.UpdateTask(taskId, updatedTask);

            tasks = _toDoListService.GetTasks();
            Assert.Single(tasks);
            Assert.Equal("Updated Task", tasks[0].Description);
        }

        [Fact]
        public void DeleteTask_TaskIsDeleted()
        {
            var task = new Task
            {
                Description = "Test Task",
                Category = "Test Category",
                Deadline = DateTime.Now.AddDays(1),
                IsCompleted = false
            };

            _toDoListService.AddTask(task);
            var tasks = _toDoListService.GetTasks();
            var taskId = tasks[0].Id;

            _toDoListService.DeleteTask(taskId);

            tasks = _toDoListService.GetTasks();
            Assert.Empty(tasks);
        }

        [Fact]
        public void MarkTaskAsCompleted_TaskIsMarkedAsCompleted()
        {
            var task = new Task
            {
                Description = "Test Task",
                Category = "Test Category",
                Deadline = DateTime.Now.AddDays(1),
                IsCompleted = false
            };

            _toDoListService.AddTask(task);
            var tasks = _toDoListService.GetTasks();
            var taskId = tasks[0].Id;

            _toDoListService.MarkTaskAsCompleted(taskId);

            tasks = _toDoListService.GetTasks();
            Assert.Single(tasks);
            Assert.True(tasks[0].IsCompleted);
        }

        [Fact]
        public void GetTasks_ReturnsAllTasks()
        {
            var task1 = new Task
            {
                Description = "Test Task 1",
                Category = "Test Category 1",
                Deadline = DateTime.Now.AddDays(1),
                IsCompleted = false
            };

            var task2 = new Task
            {
                Description = "Test Task 2",
                Category = "Test Category 2",
                Deadline = DateTime.Now.AddDays(2),
                IsCompleted = true
            };

            _toDoListService.AddTask(task1);
            _toDoListService.AddTask(task2);

            var tasks = _toDoListService.GetTasks();
            Assert.Equal(2, tasks.Count);
        }

        public void Dispose()
        {
            using (var command = new SQLiteCommand("DROP TABLE IF EXISTS TasksTest", _connection))
            {
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}