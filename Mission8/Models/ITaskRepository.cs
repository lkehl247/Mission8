using System.Collections.Generic;
using Mission8.Models;  // Ensure this matches your project's namespace for models

namespace Mission8.Data  // Ensure this matches your project's data namespace
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAllTasks();  // Changed Task -> TaskModel to avoid conflicts with System.Threading.Tasks
        TaskModel GetTaskById(int id);
        void AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
