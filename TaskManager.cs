using System.Collections.Generic;
using System.Linq;

class TaskManager
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public IEnumerable<Task> GetTasks()
    {
        return tasks.OrderBy(t => t.Priority).ThenBy(t => t.CreatedAt);
    }

    public Task GetTaskById(int id)
    {
        return tasks.FirstOrDefault(t => t.Id == id);
    }

    public bool RemoveTask(int id)
    {
        var task = GetTaskById(id);
        if (task != null)
        {
            tasks.Remove(task);
            return true;
        }
        return false;
    }
}
