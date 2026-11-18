
using System.Text.Json;
using to_do_list.Models;

namespace to_do_list.Services;

public class TaskService : ITaskService
{
    private readonly string _folderPath;
    private readonly string _filePath;

    private readonly SemaphoreSlim _lock = new(1, 1);

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public TaskService()
    {
        _folderPath = Path.Combine(
            FileSystem.AppDataDirectory,
            "todos");

        _filePath = Path.Combine(
            _folderPath,
            "tasks.json");
    }

    private async Task EnsureFileExistsAsync()
    {
        Directory.CreateDirectory(_folderPath);

        if (!File.Exists(_filePath))
        {
            await File.WriteAllTextAsync(_filePath, "[]");
        }
    }

    public async Task<List<TaskItem>> GetAllTasksAsync()
    {
        await _lock.WaitAsync();

        try
        {
            await EnsureFileExistsAsync();

            string json = await File.ReadAllTextAsync(_filePath);

            return JsonSerializer.Deserialize<List<TaskItem>>(
                json, _jsonOptions) ?? new List<TaskItem>();
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
    {
        var tasks = await GetAllTasksAsync();

        return tasks.FirstOrDefault(x => x.Id == id);
    }

    public async Task CreateTaskAsync(TaskItem task)
    {
        await _lock.WaitAsync();

        try
        {
            await EnsureFileExistsAsync();

            string json = await File.ReadAllTextAsync(_filePath);

            var tasks =
                JsonSerializer.Deserialize<List<TaskItem>>(
                    json, _jsonOptions) ?? new List<TaskItem>();

            tasks.Add(task);

            await SaveTasksAsync(tasks);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        await _lock.WaitAsync();

        try
        {
            await EnsureFileExistsAsync();

            string json = await File.ReadAllTextAsync(_filePath);

            var tasks =
                JsonSerializer.Deserialize<List<TaskItem>>(
                    json, _jsonOptions) ?? new List<TaskItem>();

            int index = tasks.FindIndex(x => x.Id == task.Id);

            if (index == -1)
                throw new InvalidOperationException("Task not found.");

            tasks[index] = task;

            await SaveTasksAsync(tasks);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        await _lock.WaitAsync();

        try
        {
            await EnsureFileExistsAsync();

            string json = await File.ReadAllTextAsync(_filePath);

            var tasks =
                JsonSerializer.Deserialize<List<TaskItem>>(
                    json, _jsonOptions) ?? new List<TaskItem>();

            tasks.RemoveAll(x => x.Id == id);

            await SaveTasksAsync(tasks);
        }
        finally
        {
            _lock.Release();
        }
    }

    private async Task SaveTasksAsync(List<TaskItem> tasks)
    {
        string json = JsonSerializer.Serialize(
            tasks, _jsonOptions);

        string tempPath = _filePath + ".tmp";

        await File.WriteAllTextAsync(tempPath, json);

        File.Move(tempPath, _filePath, overwrite: true);
    }
}
