public class TaskService
{
    private static List<Task> tasks;
    private static int id;

    public TaskService()
    {
        tasks = new List<Task>();
        id = 1;
    }

    public Task? getTaskById(int id)
    {
        return tasks.FirstOrDefault(t => t.id == id);
    }

    public void addTask(string title, string? desc, Priority priority, string? dueDate)
    {
        tasks.Add(new Task(title, desc, priority, dueDate));
    }

    public Task? updateTaskById(int id, string? title = null, string? desc = null, bool? isCompleted = null, Priority? priority = null, string? dueDate = null)
    {
        var taskToUpdate = getTaskById(id);
        if (taskToUpdate != null)
        {
            taskToUpdate.updatedAt = DateTime.Now;
            if (!string.IsNullOrEmpty(title)) taskToUpdate.title = title; 
            if (isCompleted.HasValue) taskToUpdate.isCompleted = isCompleted.Value;
            if (priority.HasValue) taskToUpdate.priority = priority.Value;
            if (!string.IsNullOrEmpty(desc)) taskToUpdate.description = desc;

            //if null, user is removing dueDate else, changing due date
            taskToUpdate.dueDate = dueDate == null ? null : DateTime.Parse(dueDate);

            tasks[id] = taskToUpdate;
            return taskToUpdate;
        }
        return null;
    }

    public Task? removeTaskById(int id)
    {
        var taskToRemove = getTaskById(id);
        return taskToRemove != null ? taskToRemove : null;
    }
}