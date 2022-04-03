using WebApplicationlabb.DAL.Models;

namespace WebApplicationlabb.DAL
{

    public interface IUserRepository : IDisposable
    {
        bool CreateUser(User user);
        ICollection<User> GetAllUsers();
        User? GetUser(int id);
        ICollection<Course>? GetUserCourses(int id);
        User? GetUserByEmail(string email);

        bool UpdateUser(int id, User user);
        bool UpdateUserName(int id, string name);
        bool UpdateUserEmail(int id, string email);
        bool DeleteUser(int id);
    }
}
