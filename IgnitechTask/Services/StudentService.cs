using IgnitechTask;
using Microsoft.EntityFrameworkCore;

public class StudentService : IStudentService
{
    private readonly MyDBContext _context;

    public StudentService(MyDBContext context)
    {
        _context = context;
    }

    public async Task<List<SubjectDTO>> GetSubjectsByStudentGuid(Guid studentGuid)
    {
        var student = await _context.Students
            .Include(s => s.Subjects)
            .FirstOrDefaultAsync(s => s.StudentCode == studentGuid);

        if (student == null)
        {
            throw new KeyNotFoundException($"Student with GUID {studentGuid} not found.");
        }

        return student.Subjects.Select(s => new SubjectDTO
        {
            Id = s.Id,
            Name = s.Name
        }).ToList();
    }

    public async Task<List<GradeDTO>> GetGradesByStudentGuidAndSubjectId(Guid studentGuid, int subjectId)
    {
        var student = await _context.Students
            .Include(s => s.Subjects)
            .ThenInclude(su => su.Grades)
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

        return subject.Grades.Select(g => new GradeDTO
        {
            Id = g.Id,
            Value = g.Value,
            CreatedOn = g.CreatedOn
        }).ToList();
    }

    public async Task<double> CalculateAverageGradeByStudentGuidAndSubjectId(Guid studentGuid, int subjectId)
    {
        var student = await _context.Students
            .Include(s => s.Subjects)
            .ThenInclude(su => su.Grades)
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

        var grades = subject.Grades;

        if (grades == null || !grades.Any())
        {
            throw new Exception($"No grades found for student with GUID {studentGuid} in subject with ID {subjectId}.");
        }

        return grades.Average(g => g.Value);
    }
}
