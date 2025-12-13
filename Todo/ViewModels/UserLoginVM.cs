using System.ComponentModel.DataAnnotations;

namespace Todo.ViewModels
{
    public class UserLoginVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
