
using to_do_list.Models;

namespace to_do_list.Services;

public interface ITaskService
{
    Task<List<TaskItem>> GetAllTasksAsync();

    Task<TaskItem?> GetTaskByIdAsync(Guid id);

    Task CreateTaskAsync(TaskItem task);

    Task UpdateTaskAsync(TaskItem task);

    Task DeleteTaskAsync(Guid id);
}
