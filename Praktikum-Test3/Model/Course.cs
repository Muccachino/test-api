using System.ComponentModel.DataAnnotations;

namespace Praktikum_Test3.Model;

public class Course
{
    public int CourseId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public ICollection<Student> Students { get; set; }
    
    public Instructor Instructor { get; set; }
}