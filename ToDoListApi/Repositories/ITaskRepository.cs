using OLA1_SofQuality.ToDoListApi.Models;

namespace OLA1_SofQuality.ToDoListApi.Repositories
{
    public interface ITaskRepository
    {
        Task<List<ToDoTask>> GetTasksAsync();
        Task<ToDoTask> GetTaskByIdAsync(int id);
        Task AddTaskAsync(ToDoTask task);
        Task<ToDoTask> UpdateTaskAsync(ToDoTask task);
        Task DeleteTaskAsync(int id);
    }
}