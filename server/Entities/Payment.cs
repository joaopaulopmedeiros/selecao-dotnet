using System.ComponentModel.DataAnnotations;

namespace App.Entities
{
    public class Payment
    {
    public int UserId { get; set; }
    public int CourseId { get; set; }

    public virtual User User { get; set; }
    public virtual Course Course { get; set; } 
    }
}
