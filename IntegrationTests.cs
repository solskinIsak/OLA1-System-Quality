using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Xunit;

namespace OLA1_SofQuality
{
    public class IntegrationTests : IDisposable
    {
        private readonly ToDoListService _toDoListService;
        //The data source needs to be set by the user copying the absolute path from the Data/OlaDB.sqlite file
        private readonly string _connectionString = "Data Source=C:\\Users\\marku\\Documents\\SOFTWARE BACHELOR\\1st Semester\\System Quality\\OLA1\\OLA1-SofQuality\\Data\\OlaDB.sqlite;Version=3;";

        public IntegrationTests()
        {
            _toDoListService = new ToDoListService("TasksTest");
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS TasksTest (Id INTEGER PRIMARY KEY AUTOINCREMENT, Description TEXT NOT NULL, Category TEXT NOT NULL, Deadline TEXT NOT NULL, IsCompleted INTEGER NOT NULL)",
                    connection);
                command.ExecuteNonQuery();
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
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("DROP TABLE IF EXISTS TasksTest", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}