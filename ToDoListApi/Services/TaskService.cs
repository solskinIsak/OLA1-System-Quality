using System.Collections.Generic;
using System.Threading.Tasks;
using OLA1_SofQuality.ToDoListApi.Models;
using OLA1_SofQuality.ToDoListApi.Repositories;

namespace OLA1_SofQuality.ToDoListApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<ToDoTask>> GetTasksAsync()
        {
            return await _taskRepository.GetTasksAsync();
        }

        public async Task<ToDoTask> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task AddTaskAsync(ToDoTask task)
        {
            await _taskRepository.AddTaskAsync(task);
        }

        public async Task<ToDoTask> UpdateTaskAsync(ToDoTask task)
        {
            var updateObject = await _taskRepository.UpdateTaskAsync(task);
            return updateObject;
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
        }
    }
} 