using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace IgnitechTask.Models
{
    public class Subject
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        
        // FKs
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
