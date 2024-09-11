using System.Collections.Generic;
using System.Threading.Tasks;
using OLA1_SofQuality.ToDoListApi.Models;

namespace OLA1_SofQuality.ToDoListApi.Services
{
    public interface ITaskService
    {
        Task<List<ToDoTask>> GetTasksAsync();
        Task<ToDoTask> GetTaskByIdAsync(int id);
        Task AddTaskAsync(ToDoTask task);
        Task<ToDoTask> UpdateTaskAsync(ToDoTask task);
        Task DeleteTaskAsync(int id);
    }
}