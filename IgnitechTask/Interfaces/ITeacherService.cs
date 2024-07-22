public interface ITeacherService
{
    Task<List<StudentDTO>> GetStudentsByTeacherGuid(Guid teacherGuid);
    Task<List<SubjectDTO>> GetSubjectsByTeacherGuidAsync(Guid teacherGuid);
}
