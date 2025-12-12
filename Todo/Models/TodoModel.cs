using Todo.Enums;

namespace Todo.Models
{
    public class TodoModel
    {
        public String Libelle { get; set; }
        public String Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State Statut { get; set; }
    }
}
