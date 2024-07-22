using IgnitechTask;
// Za ovu sam klasu koristio AI, prompt je bio slijedeci: "Based on the 4 models I have provided,
// create a DataSeeder class that will seed the Sqlite database with 5 teachers, 3 students, 3 subjects, and 2 grades." 
public static class DataSeeder
{
    public static void SeedData(MyDBContext context)
    {
        
        context.Database.EnsureCreated();

        if (!context.Teachers.Any())
        {
            
            var teachers = new[]
            {
                new Teacher { FirstName = "John", LastName = "Doe" },
                new Teacher { FirstName = "Jane", LastName = "Smith" },
                new Teacher { FirstName = "Jim", LastName = "Beam" },
                new Teacher { FirstName = "Jack", LastName = "Daniels" },
                new Teacher { FirstName = "Jill", LastName = "Valentine" }
            };
            context.Teachers.AddRange(teachers);

            
            var students = new[]
            {
                new Student { FirstName = "Alice", LastName = "Johnson", Teacher = teachers[0] },
                new Student { FirstName = "Bob", LastName = "Brown", Teacher = teachers[1] },
                new Student { FirstName = "Charlie", LastName = "Davis", Teacher = teachers[2] }
            };
            context.Students.AddRange(students);

            
            var subjects = new[]
            {
                new Subject { Name = "Mathematics", Teacher = teachers[0], Student = students[0] },
                new Subject { Name = "Science", Teacher = teachers[1], Student = students[1] },
                new Subject { Name = "History", Teacher = teachers[2], Student = students[2] }
            };
            context.Subjects.AddRange(subjects);

            
            var grades = new[]
            {
                new Grade { Value = 95, Subject = subjects[0] },
                new Grade { Value = 88, Subject = subjects[1] }
            };
            context.Grades.AddRange(grades);

            
            context.SaveChanges();
        }
    }
}
