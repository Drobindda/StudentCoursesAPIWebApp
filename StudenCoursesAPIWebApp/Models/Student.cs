namespace StudentCoursesAPIWebApp.Models
{
    public class Student
    {
        public Student()
        {
            StudentCourses = new List<StudentCourse>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
