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
            Console.Write("Enter list name: ");
            string listName = Console.ReadLine();

            if (!taskLists.ContainsKey(listName))
            {
                taskLists[listName] = new List<Task>();
            }

            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            Console.Write("Enter task deadline (yyyy-mm-dd): ");
            DateTime deadline;
            DateTime.TryParse(Console.ReadLine(), out deadline);

            taskLists[listName].Add(new Task { Title = title, Deadline = deadline });

            Console.WriteLine("Task added successfully. Press Enter to continue.");
            Console.ReadLine();
        }

        private void UpdateTask()
        {
            Console.Write("Enter list name: ");
            string listName = Console.ReadLine();

            if (taskLists.ContainsKey(listName))
            {
                Console.Write("Enter task index: ");
                int index;
                if (int.TryParse(Console.ReadLine(), out index) && index < taskLists[listName].Count)
                {
                    Console.Write("Enter new title: ");
                    string newTitle = Console.ReadLine();

                    Console.Write("Enter new deadline (yyyy-mm-dd): ");
                    DateTime newDeadline;
                    DateTime.TryParse(Console.ReadLine(), out newDeadline);

                    taskLists[listName][index].Title = newTitle;
                    taskLists[listName][index].Deadline = newDeadline;

                    Console.WriteLine("Task updated successfully. Press Enter to continue.");
                }
                else
                {
                    Console.WriteLine("Invalid index. Press Enter to continue.");
                }
            }
            else
            {
                Console.WriteLine("List does not exist. Press Enter to continue.");
            }
            Console.ReadLine();
        }

        private void DeleteTask()
        {
            Console.Write("Enter list name: ");
            string listName = Console.ReadLine();

            if (taskLists.ContainsKey(listName))
            {
                Console.Write("Enter task index: ");
                int index;
                if (int.TryParse(Console.ReadLine(), out index) && index < taskLists[listName].Count)
                {
                    taskLists[listName].RemoveAt(index);
                    Console.WriteLine("Task deleted successfully. Press Enter to continue.");
                }
                else
                {
                    Console.WriteLine("Invalid index. Press Enter to continue.");
                }
            }
            else
            {
                Console.WriteLine("List does not exist. Press Enter to continue.");
            }
            Console.ReadLine();
        }

        private void MarkTaskAsCompleted()
        {
            Console.Write("Enter list name: ");
            string listName = Console.ReadLine();

            if (taskLists.ContainsKey(listName))
            {
                Console.Write("Enter task index: ");
                int index;
                if (int.TryParse(Console.ReadLine(), out index) && index < taskLists[listName].Count)
                {
                    taskLists[listName][index].IsCompleted = true;
                    Console.WriteLine("Task marked as completed. Press Enter to continue.");
                }
                else
                {
                    Console.WriteLine("Invalid index. Press Enter to continue.");
                }
            }
            else
            {
                Console.WriteLine("List does not exist. Press Enter to continue.");
            }
            Console.ReadLine();
        }

        private void ViewTasks()
        {
            foreach (var list in taskLists)
            {
                Console.WriteLine($"\nList: {list.Key}");
                for (int i = 0; i < list.Value.Count; i++)
                {
                    var task = list.Value[i];
                    Console.WriteLine($"{i}. {task.Title} - {(task.IsCompleted ? "Completed" : "Pending")} - Due: {task.Deadline.ToShortDateString()}");
                }
            }
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
        }
    }

    public class Task
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}
