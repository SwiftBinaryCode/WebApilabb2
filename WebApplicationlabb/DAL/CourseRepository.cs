using WebApplicationlabb.DAL.Models;

namespace WebApplicationlabb.DAL
{
    public class CourseRepository : ICourseRepository, IDisposable
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCourse(Course course)
        {
            if (_context.Courses.Any(c => c.Name == course.Name)) return false;

            _context.Courses.Add(course);
            _context.SaveChanges();
            return true;
        }

        public bool ListUserForCourse(User user, int id)
        {
            var course = _context.Courses.Find(id);
            var getUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if (course is null || getUser is null) return false;

            course.Users.Add(getUser);
            getUser.Courses.Add(course);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course? GetCourse(int id)
        {
            return _context.Courses.Find(id);
        }
        public Course? GetCourseByNumber(int number)
        {
            return _context.Courses.Find(number);
        }
       
        public ICollection<User>? GetUserCourses(int id)
        {
            var getUser = _context.Courses.Find(id);

            return getUser == null ? null : getUser.Users.ToList();
        }

        public bool UpdateCourse(int id, Course course)
        {
            var existingCourse = _context.Courses.Find(id);
            if (existingCourse is null) return false;

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.Number = course.Number;
            existingCourse.Level = course.Level;
            existingCourse.Status = course.Status;
            existingCourse.Length = course.Length;
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCourseName(int id, string name)
        {
            var course = _context.Courses.Find(id);
            if (course is null) return false;

            course.Name = name;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
