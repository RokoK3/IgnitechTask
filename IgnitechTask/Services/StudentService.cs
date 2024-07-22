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
}
