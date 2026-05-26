using System;
using System.Collections.Generic;

// =========================================================
// 1. طبقة الوصول للبيانات (Data Access Layer - DAL)
// =========================================================
namespace ToDoSolution.DAL
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }

    public class TodoRepository
    {
        private static List<TodoTask> _tasks = new List<TodoTask>
        {
            new TodoTask { Id = 1, Title = "دراسة محاضرة الـ N-tier", IsCompleted = false },
            new TodoTask { Id = 2, Title = "تطبيق مثال الـ MVC العملي", IsCompleted = true }
        };

        public List<TodoTask> GetAllTasks() => _tasks;

        public void AddTask(TodoTask task)
        {
            task.Id = _tasks.Count + 1;
            _tasks.Add(task);
        }
    }
}

// =========================================================
// 2. طبقة منطق العمل (Business Logic Layer - BLL)
// =========================================================
namespace ToDoSolution.BLL
{
    using ToDoSolution.DAL;

    public class TodoService
    {
        private readonly TodoRepository _repository = new TodoRepository();

        public List<TodoTask> GetTasksForDisplay() => _repository.GetAllTasks();

        public bool CreateNewTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return false;

            var newTask = new TodoTask { Title = title, IsCompleted = false };
            _repository.AddTask(newTask);
            return true;
        }
    }
}
