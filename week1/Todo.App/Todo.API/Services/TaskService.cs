public class TaskService
{
    private static List<Task> tasks;
    private static int id;

    public TaskService()
    {
        tasks = new List<Task>();
        id = 1;
    }

    public List<Task>? getAllTasksByFilters(string? filter, string? dueBefore = null, Priority? priority = null)
    {
        IEnumerable<Task> filteredTasks = tasks;
        if (!string.IsNullOrEmpty(filter)) return tasks;

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

    public Task? getTaskById(int id)
    {
        return tasks.FirstOrDefault(t => t.id == id);
    }

    public void addTask(string title, string? desc, Priority priority, string? dueDate)
    {
        tasks.Add(new Task(id, title, desc, priority, dueDate));
        id++;
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