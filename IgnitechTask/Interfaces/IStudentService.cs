public interface IStudentService
{
    Task<List<SubjectDTO>> GetSubjectsByStudentGuid(Guid studentGuid);
}