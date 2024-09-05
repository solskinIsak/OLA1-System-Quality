namespace OLA1_SofQuality;

public class Program
{
    private static ToDoListService toDoListService = new ToDoListService();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("To-Do List Application");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Update Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Mark Task as Completed");
            Console.WriteLine("5. View Tasks");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Task task = AddTask();
                    toDoListService.AddTask(task);
                    Console.WriteLine("Task added successfully.");
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
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public static Task AddTask()
    {
        var task = new Task();
        Console.Write("Enter task description: ");
        task.Description = Console.ReadLine();
        Console.Write("Enter task category: ");
        task.Category = Console.ReadLine();
        Console.Write("Enter task deadline (yyyy-mm-dd): ");
        task.Deadline = DateTime.Parse(Console.ReadLine());
        task.IsCompleted = false;
        return task;
    }

    public static void UpdateTask()
    {
        Console.Write("Enter task ID to update: ");
        var id = int.Parse(Console.ReadLine());
        var task = new Task();
        Console.Write("Enter new task description: ");
        task.Description = Console.ReadLine();
        Console.Write("Enter new task category: ");
        task.Category = Console.ReadLine();
        Console.Write("Enter new task deadline (yyyy-mm-dd): ");
        task.Deadline = DateTime.Parse(Console.ReadLine());
        task.IsCompleted = false;
        toDoListService.UpdateTask(id, task);
        Console.WriteLine("Task updated successfully.");
    }

    public static void DeleteTask()
    {
        Console.Write("Enter task ID to delete: ");
        var id = int.Parse(Console.ReadLine());
        toDoListService.DeleteTask(id);
        Console.WriteLine("Task deleted successfully.");
    }

    public static void MarkTaskAsCompleted()
    {
        Console.Write("Enter task ID to mark as completed: ");
        var id = int.Parse(Console.ReadLine());
        toDoListService.MarkTaskAsCompleted(id);
        Console.WriteLine("Task marked as completed.");
    }

    public static void ViewTasks()
    {
        var tasks = toDoListService.GetTasks();
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Category: {task.Category}, Deadline: {task.Deadline}, Completed: {task.IsCompleted}");
        }
    }
}