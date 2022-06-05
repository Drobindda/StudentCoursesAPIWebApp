namespace StudentCoursesAPIWebApp.Models
{
    public class CourseType
    {
        CourseType()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
