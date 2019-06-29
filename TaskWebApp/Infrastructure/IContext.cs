using System.Collections.Generic;
using TaskWebApp.Model;

namespace TaskWebApp.DAT
{
    public interface IContext
    {
        void ChangeTaskFieldIsFinshed(string id);
        void CreateTask(TodoTask source);
        IEnumerable<TodoTask> GetAllTodoTasks();
        TodoTask GetTaskById(string id);
        void RemoveTaskById(string id);
        void UpdateTaskProperties(TodoTask target);
    }
}