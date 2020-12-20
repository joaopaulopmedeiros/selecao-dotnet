using System.ComponentModel.DataAnnotations;

namespace App.Resources
{
    public class EnrollmentRequest
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int CourseId { get; set; }
    }
}