using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("GetSubjectsByStudentGuid")]
    public async Task<IActionResult> GetSubjectsByStudentGuid(Guid studentGuid)
    {
        try
        {
            var subjects = await _studentService.GetSubjectsByStudentGuid(studentGuid);
            return Ok(subjects);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
