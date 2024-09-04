using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoManager manager = new ToDoManager();
            manager.Run();
        }
    }

    public class ToDoManager
    {
        private Dictionary<string, List<Task>> taskLists;

        public ToDoManager()
        {
            taskLists = new Dictionary<string, List<Task>>();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Update Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Mark Task as Completed");
                Console.WriteLine("5. View Tasks");
                Console.WriteLine("6. Exit");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        UpdateTask();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        MarkTaskAsCompleted();
                        break;
                    case "5":
                        ViewTasks();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void AddTask()
        {
          
        }

        private void UpdateTask()
        {
            
        }

        private void DeleteTask()
        {
            
        }

        private void MarkTaskAsCompleted()
        {
           
        }

        private void ViewTasks()
        {
            
        }
    }

    public class Task
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}
