namespace StudentCoursesAPIWebApp.Models
{
    public class RateType
    {
        public RateType()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
