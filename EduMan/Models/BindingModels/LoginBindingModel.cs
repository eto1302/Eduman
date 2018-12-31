using System.ComponentModel.DataAnnotations;

namespace Eduman.Models.BindingModels
{
    public class LoginBindingModel
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
