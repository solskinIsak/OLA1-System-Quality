namespace OLA1_SofQuality;

public class ToDoList
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void UpdateTask(int id, Task updatedTask)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.Description = updatedTask.Description;
            task.Category = updatedTask.Category;
            task.Deadline = updatedTask.Deadline;
            task.IsCompleted = updatedTask.IsCompleted;
        }
    }

    public void DeleteTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
        }
    }

    public void MarkTaskAsCompleted(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
        }
    }

    public List<Task> GetTasks()
    {
        return tasks;
    }
}