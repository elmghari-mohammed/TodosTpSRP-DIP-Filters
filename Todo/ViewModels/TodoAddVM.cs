using System.ComponentModel.DataAnnotations;
using Todo.Enums;

namespace Todo.ViewModels
{
    public class TodoAddVM
    {
        [Required(ErrorMessage ="Le libelli est obligatoire")]
        public String Libelle { get; set; }
        [Required]
        public String Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        [Required]
        public State Statut { get; set; }

    }
}
