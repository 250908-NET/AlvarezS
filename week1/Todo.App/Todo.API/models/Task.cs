using System;
using System.ComponentModel.DataAnnotations;
public class Task
{
    private string? desc;
    private string? dueDate1;

    public int id { get; set; }
    [Required]
    [MaxLength(100)]
    public string title { get; set; }
    [MaxLength(500)]
    public string? description { get; set; }
    public bool isCompleted { get; set; }
    public Priority priority { get; set; }
    public DateTime? dueDate { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }

    public Task()
    {
        id = 0; title = "";
        isCompleted = false;
        createdAt = DateTime.Now;
        updatedAt = DateTime.Now;
    }

    public Task(int id, string title, string? desc, Priority priority, string? dueDate)
    {
        this.id = id;
        this.title = title;
        this.desc = desc;
        this.priority = priority;
        this.createdAt = DateTime.Now;
        this.dueDate = dueDate != null ? this.dueDate = DateTime.Parse(dueDate) : (DateTime?)null;
    }
}