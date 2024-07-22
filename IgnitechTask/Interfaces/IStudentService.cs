public interface IStudentService
{
    Task<List<SubjectDTO>> GetSubjectsByStudentGuid(Guid studentGuid);

    Task<List<GradeDTO>> GetGradesByStudentGuidAndSubjectId(Guid studentGuid, int subjectId);

    Task<double> CalculateAverageGradeByStudentGuidAndSubjectId(Guid studentGuid, int subjectId);
}