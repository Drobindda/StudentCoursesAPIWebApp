using Microsoft.EntityFrameworkCore;

namespace StudentCoursesAPIWebApp.Models
{
    public class StudentCoursesAPIContext: DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }

        public StudentCoursesAPIContext(DbContextOptions<StudentCoursesAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
