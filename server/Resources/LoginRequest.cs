using System.ComponentModel.DataAnnotations;

namespace App.Resources
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(5, ErrorMessage = "Este campo deve conter o formato adequado")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Este campo deve conter entre 8 e 30 caracteres")]
        public string Password { get; set; }

    }
}