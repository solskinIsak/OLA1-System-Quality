namespace OLA1_SofQuality.ToDoListApi.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}