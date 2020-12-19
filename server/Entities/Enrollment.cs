using System.ComponentModel.DataAnnotations;

namespace App.Entities
{
    public class Enrollment
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public virtual User User { get; set; }
    [Required]
    public virtual Course Course { get; set; } 
    }
}
