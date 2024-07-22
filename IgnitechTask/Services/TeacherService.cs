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

    public async Task<List<SubjectDTO>> GetSubjectsByTeacherGuid(Guid teacherGuid)
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

    public async Task<TeacherDTO> GetTeacherByStudentGuidAndSubjectId(Guid studentGuid, int subjectId)
    {
        var student = await _context.Students
            .Include(s => s.Subjects)
            .ThenInclude(su => su.Teacher)
            .FirstOrDefaultAsync(s => s.StudentCode == studentGuid);

        if (student == null)
        {
            throw new Exception($"Student with GUID {studentGuid} not found.");
        }

        var subject = student.Subjects.FirstOrDefault(s => s.Id == subjectId);

        if (subject == null)
        {
            throw new Exception($"Subject with ID {subjectId} not found for the student.");
        }

        var teacher = subject.Teacher;

        if (teacher == null)
        {
            throw new Exception($"Teacher not found for the subject with ID {subjectId}.");
        }

        return new TeacherDTO
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName
        };
    }
}
