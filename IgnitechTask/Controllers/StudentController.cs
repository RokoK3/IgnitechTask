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

    [HttpGet("GetGradesByStudentGuidAndSubjectId")]
    public async Task<IActionResult> GetGradesByStudentGuidAndSubjectId(Guid studentGuid, int subjectId)
    {
        try
        {
            var grades = await _studentService.GetGradesByStudentGuidAndSubjectId(studentGuid, subjectId);
            return Ok(grades);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("GetAverageGradeByStudentGuidAndSubjectId")]
    public async Task<IActionResult> GetAverageGradeByStudentGuidAndSubjectId(Guid studentGuid, int subjectId)
    {
        try
        {
            var averageGrade = await _studentService.CalculateAverageGradeByStudentGuidAndSubjectId(studentGuid, subjectId);
            return Ok(averageGrade);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
