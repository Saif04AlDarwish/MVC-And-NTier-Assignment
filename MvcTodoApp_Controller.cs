using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MvcTodoApp.Controllers
{
    // الـ Model: يمثل بنية البيانات داخل نمط الـ MVC
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }

    // الـ Controller: صلة الوصل التي تتحكم بالطلبات وتربط الـ Model بالـ View
    public class TodoController : Controller
    {
        private static List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "رفع الأكواد الصافية على حساب GitHub الشخصي", IsCompleted = false }
        };

        public IActionResult Index() => View(_todoList);

        [HttpPost]
        public IActionResult Create(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                _todoList.Add(new TodoItem { Id = _todoList.Count + 1, Title = title, IsCompleted = false });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
