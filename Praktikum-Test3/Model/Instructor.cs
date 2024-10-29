using System.ComponentModel.DataAnnotations;

namespace Praktikum_Test3.Model;

public class Instructor
{
    public int InstructorId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    public DateOnly EmployedSince { get; set; }
    
    public ICollection<Course> CoursesTaught { get; set; }
}