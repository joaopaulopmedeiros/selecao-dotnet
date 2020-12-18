using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace App.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Price { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
