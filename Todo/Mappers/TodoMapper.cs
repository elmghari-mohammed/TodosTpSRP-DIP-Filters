using Todo.Models;
using Todo.ViewModels;

namespace Todo.Mappers
{
    public class TodoMapper
    {
        public static TodoModel GetTodoFromTodoAddVM(TodoAddVM vm)
        {


            return new TodoModel
            {
                Libelle = vm.Libelle,
                Description = vm.Description,
                DateLimite = vm.DateLimite,
                Statut = vm.Statut
            };
        }
    }
}
