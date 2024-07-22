using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace IgnitechTask.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid StudentCode { get; set; } = Guid.NewGuid();

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
