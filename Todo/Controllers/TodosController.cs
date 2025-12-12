using Microsoft.AspNetCore.Mvc;
using Todo.ViewModels;
using Todo.Models;
using Todo.Mappers;
using System.Text.Json;
using Todo.Services;

namespace Todo.Controllers
{
    public class TodosController : Controller
    {
        ISessionManagerService session;

        public TodosController(ISessionManagerService session)
        {
            this.session = session;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TodoAddVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }


            List<TodoModel> list;

            if (HttpContext.Session.GetString("todos") == null)
            {
                list = new List<TodoModel>();  
            }
            else
            {
                list = JsonSerializer.Deserialize<List<TodoModel>>(HttpContext.Session.GetString("todos"));
            }


            TodoModel todo = TodoMapper.GetTodoFromTodoAddVM(vm);
            list.Add(todo);

            session.Add("todos",list, HttpContext);



            return RedirectToAction(nameof(Index));
        }


    }
}
