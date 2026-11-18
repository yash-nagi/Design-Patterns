using to_do_list.Models;

public interface IOperations
{
    TaskItem CreateTask(string title, string notes, string priority, string category, bool reminderEnabled);
}