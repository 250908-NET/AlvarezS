public class Task
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public bool isCompleted { get; set; }
    public Priority priority { get; set; }
    public DateTime dueDate { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }

    public Task()
    {
        id = 0; title = ""; description = ""; isCompleted = false;
        dueDate = DateTime.Now;
        createdAt = DateTime.Now;
        updatedAt = DateTime.Now;
    }
}