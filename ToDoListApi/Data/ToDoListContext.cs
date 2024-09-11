using Microsoft.EntityFrameworkCore;

namespace OLA1_SofQuality.ToDoListApi.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }

        public DbSet<Models.ToDoTask> Tasks { get; set; }
    }
}