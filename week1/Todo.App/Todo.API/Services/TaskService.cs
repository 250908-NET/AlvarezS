public class TaskService
{
    private static List<TaskItem> tasks = new List<TaskItem>();
    private static int id;

    public TaskService()
    {
        id = 1;
    }

    public List<TaskItem>? getAllTasksByFilters(string username, string? filter = null, string? dueBefore = null, Priority? priority = null)
    {
        IEnumerable<TaskItem> filteredTasks = tasks;
        if (string.IsNullOrEmpty(filter)) return tasks;

        switch (filter)
        {
            case "isCompleted":
                filteredTasks = filteredTasks.Where(t => t.isCompleted);
                break;

            case "priority":
                if (priority.HasValue)
                    filteredTasks = filteredTasks.Where(t => t.priority == priority);
                
                break;

            case "dueBefore":
                if (!string.IsNullOrEmpty(dueBefore) && DateTime.TryParse(dueBefore, out var dueDate))
                    filteredTasks = filteredTasks.Where(t => t.dueDate.HasValue && t.dueDate.Value < dueDate);
                break;

            default:
                return null;
        }
        return filteredTasks.ToList();
    }

    public TaskItem? getTaskById(string username, int id)
    {
        return tasks.FirstOrDefault(t => t.id == id && t.username == username);
    }

    public TaskItem addTask(string username, string title, Priority priority = Priority.LOW, string? desc = null, string? dueDate = null)
    {
        TaskItem newTask = new TaskItem(username, id, title, desc, priority, dueDate);
        tasks.Add(newTask);
        id++;
        return newTask;
    }

    public TaskItem? updateTaskById(string username, int id, string? title = null, string? desc = null, bool? isCompleted = null, Priority? priority = null, string? dueDate = null)
    {
        var taskToUpdate = getTaskById(username, id);
        if (taskToUpdate != null)
        {
            taskToUpdate.updatedAt = DateTime.Now;
            if (!string.IsNullOrEmpty(title)) taskToUpdate.title = title; 
            if (isCompleted.HasValue) taskToUpdate.isCompleted = isCompleted.Value;
            if (priority.HasValue) taskToUpdate.priority = priority.Value;
            if (!string.IsNullOrEmpty(desc)) taskToUpdate.description = desc;

            //if null, user is removing dueDate else, changing due date
            taskToUpdate.dueDate = dueDate == null ? null : DateTime.Parse(dueDate);

            return taskToUpdate;
        }
        return null;
    }

    public TaskItem? removeTaskById(string username, int id)
    {
        var taskToRemove = getTaskById(username, id);
        if (taskToRemove != null) tasks.Remove(taskToRemove);
        return taskToRemove != null ? taskToRemove : null;
    }
}