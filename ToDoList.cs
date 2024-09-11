namespace OLA1_SofQuality;

public class ToDoList
{
    private List<SofQualityTask> tasks = new List<SofQualityTask>();

    public void AddTask(SofQualityTask sofQualityTask)
    {
        tasks.Add(sofQualityTask);
    }

    public void UpdateTask(int id, SofQualityTask updatedSofQualityTask)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.Description = updatedSofQualityTask.Description;
            task.Category = updatedSofQualityTask.Category;
            task.Deadline = updatedSofQualityTask.Deadline;
            task.IsCompleted = updatedSofQualityTask.IsCompleted;
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

    public List<SofQualityTask> GetTasks()
    {
        return tasks;
    }
}