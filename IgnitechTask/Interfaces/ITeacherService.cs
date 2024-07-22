public interface ITeacherService
{
    Task<List<StudentDTO>> GetStudentsByTeacherGuid(Guid teacherGuid);
    Task<List<SubjectDTO>> GetSubjectsByTeacherGuid(Guid teacherGuid);
    Task<TeacherDTO> GetTeacherByStudentGuidAndSubjectId(Guid studentGuid, int subjectId);
}
