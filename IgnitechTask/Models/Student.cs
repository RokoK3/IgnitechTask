public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid StudentCode { get; set; } = Guid.NewGuid();
    public int TeacherId { get; set; } 
    public Teacher Teacher { get; set; }
    public ICollection<Subject> Subjects { get; set; }
}
