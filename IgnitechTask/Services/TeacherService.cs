using IgnitechTask;
using Microsoft.EntityFrameworkCore;

public class TeacherService : ITeacherService
{
    private readonly MyDBContext _context;

    public TeacherService(MyDBContext context)
    {
        _context = context;
    }

    public async Task<List<StudentDTO>> GetStudentsByTeacherGuid(Guid teacherGuid)
    {
        var teacher = await _context.Teachers
            .Include(t => t.Students)
            .FirstOrDefaultAsync(t => t.TeacherCode == teacherGuid);

        if (teacher == null)
        {
            throw new Exception($"Teacher with GUID {teacherGuid} not found.");
        }

        return teacher.Students.Select(s => new StudentDTO
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName
        }).ToList();
    }

    public async Task<List<SubjectDTO>> GetSubjectsByTeacherGuidAsync(Guid teacherGuid)
    {
        var teacher = await _context.Teachers
            .Include(t => t.Subjects)
            .FirstOrDefaultAsync(t => t.TeacherCode == teacherGuid);

        if (teacher == null)
        {
            throw new Exception($"Teacher with GUID {teacherGuid} not found.");
        }

        return teacher.Subjects.Select(s => new SubjectDTO
        {
            Id = s.Id,
            Name = s.Name
        }).ToList();
    }
}
