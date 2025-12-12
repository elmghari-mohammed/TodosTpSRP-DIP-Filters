using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;

namespace Todo.ViewModels
{
    public class TodoEditVM
    {
        public String Libelle { get; set; }
        public String Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State Statut { get; set; }

    }
}
