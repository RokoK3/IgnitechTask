using System.ComponentModel.DataAnnotations;

namespace IgnitechTask.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid TeacherCode { get; set; } = Guid.NewGuid();

        public ICollection<Subject> Subjects { get; set; }
    }
}
