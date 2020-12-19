using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace App.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve conter o formato adequado")]
        [DisplayFormat(DataFormatString = "XXX.XXX.XXX-XX")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(5, ErrorMessage = "Este campo deve conter o formato adequado")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Este campo deve conter entre 8 e 30 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "Este campo deve conter o formato adequado")]
        [DisplayFormat(DataFormatString = "XXX.XXX.XXX.XXXXX")]
        public string CreditCard { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
