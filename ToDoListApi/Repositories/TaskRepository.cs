using Microsoft.EntityFrameworkCore;
using OLA1_SofQuality.ToDoListApi.Data;
using OLA1_SofQuality.ToDoListApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLA1_SofQuality.ToDoListApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoListContext _context;

        public TaskRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoTask>> GetTasksAsync()
        {
            return await _context.Tasks.Select(t => new ToDoTask
            {
                Id = t.Id,
                Description = t.Description,
                Category = t.Category,
                Deadline = t.Deadline,
                IsCompleted = t.IsCompleted
            }).ToListAsync<ToDoTask>();
        }

        public async Task<ToDoTask> GetTaskByIdAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) throw new Exception("Task not found");

            return new ToDoTask
            {
                Id = task.Id,
                Description = task.Description,
                Category = task.Category,
                Deadline = task.Deadline,
                IsCompleted = task.IsCompleted
            };
        }

        public async Task AddTaskAsync(ToDoTask task)
        {
            var entity = new ToDoTask
            {
                Id = task.Id,
                Description = task.Description,
                Category = task.Category,
                Deadline = task.Deadline,
                IsCompleted = task.IsCompleted
            };

            await _context.Tasks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ToDoTask> UpdateTaskAsync(ToDoTask task)
        {
            var entity = await _context.Tasks.FindAsync(task.Id);
            if (entity == null) throw new Exception("Task not found");

            entity.Description = task.Description;
            entity.Category = task.Category;
            entity.Deadline = task.Deadline;
            entity.IsCompleted = task.IsCompleted;

            
           var response = _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null) throw new Exception("Task not found");
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}