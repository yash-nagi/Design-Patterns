using System.Runtime.CompilerServices;
using to_do_list.Models;

public class Operations : IOperations
{
    public TaskItem CreateTask(string title,
                                string notes,
                                string priority,
                                string category,
                                bool reminderEnabled,
                                DateTime dueDate = default(DateTime),
                                TimeSpan dueTime = default(TimeSpan))
    {
        return new TaskItem
        {
            Title = title,
            Notes = notes,
            DueDate = dueDate == default(DateTime) ? DateTime.Today : dueDate,
            DueTime = dueTime == default(TimeSpan) ? new TimeSpan(10, 0, 0) : dueTime,
            Priority = priority,
            Category = category,
            ReminderEnabled = reminderEnabled
        };
    }
    public TaskItem AddSubTask(TaskItem task)
    {
        task.Subtasks.Add(new SubTask
        {
            Title = "Draft the outline"
        });
        return task;
    }
}