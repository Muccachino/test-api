using System.ComponentModel.DataAnnotations;

namespace Praktikum_Test3.Model;

public class Student
{
    public int StudentId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public DateOnly EnrollementDate { get; set; }
    
    public ICollection<Course> Courses { get; set; }
    
}