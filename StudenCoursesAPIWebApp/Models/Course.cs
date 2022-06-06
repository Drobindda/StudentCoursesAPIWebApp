namespace StudentCoursesAPIWebApp.Models
{
    public class Course
    {
        public Course()
        {
            StudentCourses = new List<StudentCourse>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? CourseTypeId { get; set; }
        public int? RateTypeId { get; set; }
        public virtual CourseType? CourseType { get; set; }
        public virtual RateType? RateType { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
