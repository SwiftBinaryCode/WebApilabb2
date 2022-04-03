using System.Text.Json.Serialization;

namespace WebApplicationlabb.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Course> Courses { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
            Courses = new HashSet<Course>();

        }

        public User()
        {
            Courses = new HashSet<Course>();
        }
    }
}
