using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("GetStudentsByTeacherGuid")]
    public async Task<IActionResult> GetStudentsByTeacherGuid(Guid teacherGuid)
    {
        try
        {
            var students = await _teacherService.GetStudentsByTeacherGuid(teacherGuid);
            return Ok(students);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("GetSubjectsByTeacherGuid")]
    public async Task<IActionResult> GetSubjectsByTeacherGuid(Guid teacherGuid)
    {
        try
        {
            var subjects = await _teacherService.GetSubjectsByTeacherGuid(teacherGuid);
            return Ok(subjects);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("GetTeacherByStudentGuidAndSubjectId")]
    public async Task<IActionResult> GetTeacherByStudentGuidAndSubjectId(Guid studentGuid, int subjectId)
    {
        try
        {
            var teacher = await _teacherService.GetTeacherByStudentGuidAndSubjectId(studentGuid, subjectId);
            return Ok(teacher);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    
}
