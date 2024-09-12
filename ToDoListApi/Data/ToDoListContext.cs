using Microsoft.EntityFrameworkCore;
using OLA1_SofQuality.ToDoListApi.Models;

namespace OLA1_SofQuality.ToDoListApi.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
        }
    }
}