using System.ComponentModel.DataAnnotations;

namespace Praktikum_Test3.Model.DTO;

public class CreateStudentDTO
{
    [Required(ErrorMessage = "First Name is required!")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last Name is required!")]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public List<int> Courses { get; set; }
}