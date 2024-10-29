using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktikum_Test3.Data;
using Praktikum_Test3.Model;
using Praktikum_Test3.Model.DTO;

namespace Praktikum_Test3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly DataContext _context;

    public StudentController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents(int pageIndex = 0, int pageSize = 10)
    {
        var response = new BaseResponseModel();
        try
        {
            var studentCount = _context.Student.Count();
            var studentList = await _context.Student
                .Include(x => x.Courses)
                .Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            response.Status = true;
            response.Message = "Success";
            response.Data = new { Students = studentList, Count = studentCount };

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = "Something went wrong";
            return BadRequest(response);
        }

    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var response = new BaseResponseModel();
        try
        {
            var student = await _context.Student
                .Include(x => x.Courses)
                .Where(x => x.StudentId == id)
                .FirstOrDefaultAsync();

            if (student == null)
            {           
                response.Status = false;
                response.Message = "Record not existing";
                return BadRequest(response);
                
            }

            response.Status = true;
            response.Message = "Success";
            response.Data = student;

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = "Something went wrong";
            return BadRequest(response);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(CreateStudentDTO dto)
    {
        var response = new BaseResponseModel();

        try
        {
            if (ModelState.IsValid)
            {
                var courses = await _context.Course.Where(x => dto.Courses.Contains(x.CourseId)).ToListAsync();

                var newStudent = new Student()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Courses = courses,
                };

                _context.Student.Add(newStudent);
                await _context.SaveChangesAsync();

                response.Status = true;
                response.Message = "Created Successfully";
                response.Data = newStudent;

                return Ok(response);
            }

            response.Status = false;
            response.Message = "Validation failed";
            response.Data = ModelState;
            return BadRequest(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = "Something went wrong!";
            return BadRequest(response);
        }

    }
}