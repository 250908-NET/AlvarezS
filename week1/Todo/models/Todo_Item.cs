public class Todo_Item
{
    public int id { get; set; }
    public string title { get; set; }
    public bool isCompleted { get; set; }
    public DateTime createdDate { get; set; }

    public Todo_Item()
    {
        id = 0;
        title = "";
        isCompleted = false;
        createdDate = DateTime.Now;
    }

    public Todo_Item(int id, string title, bool isCompleted, DateTime createdDate)
    {
        this.id = id;
        this.title = title;
        this.isCompleted = isCompleted;
        this.createdDate = createdDate;
    }

    public void switchMark() {
        this.isCompleted = !this.isCompleted;
    }

    public override string ToString()
    {
        return this.isCompleted
        ? $"[{this.id}] {this.title} ({this.createdDate.ToShortDateString()}) - ✅ Complete"
        : $"[{this.id}] {this.title} ({this.createdDate.ToShortDateString()}) - ⭕ Not Complete";

    }
}