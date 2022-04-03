using System.Text.Json.Serialization;

namespace WebApplicationlabb.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        public Course()
        {
            Users = new HashSet<User>();
        }
    }
}
