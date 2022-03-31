using WebApplicationlabb.DAL.Models;

namespace WebApplicationlabb.DAL
{
    public interface ICourseRepository : IDisposable
    {
        bool CreateCourse(Course course);
        bool ListUserForCourse(User user, int id);
        ICollection<Course> GetAllCourses();
        Course? GetCourse(int id);
        ICollection<User>? GetUserCourses(int id);
        bool UpdateCourse(int id, Course course);
        bool UpdateCourseName(int id, string name);

        Course? GetCourseByNumber(int number);

        bool DeleteCourse(int id);


        }
}
