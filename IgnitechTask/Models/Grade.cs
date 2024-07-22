using System;

public class Grade
{
    public int Id { get; set; }
    public int Value { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int SubjectId { get; set; }

    public Subject Subject { get; set; }
}
