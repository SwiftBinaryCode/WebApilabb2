using WebApplicationlabb.DAL.Models;

namespace WebApplicationlabb.DAL
{
    public interface ICourseRepository : IDisposable
    {
        bool CreateCourse(Course course);
        ICollection<Course> GetAllCourses();
        ICollection<User>? GetCourseUsers(int id);
        bool AddUserToCourse(int groupId, int userId);
        
   
        Course? GetCourse(int id);
        Course? GetCourseByNumber(string courseNumber);

        bool UpdateCourse(int id, Course course);
        bool UpdateCourseName(int id, string name);

      

        bool DeleteCourse(int id);


        }
}
