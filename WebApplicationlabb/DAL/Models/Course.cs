using System.Text.Json.Serialization;

namespace WebApplicationlabb.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public int Length { get; set; }
        public string Level { get; set; }
        public string Status { get; set; } 
       

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        public Course()
        {
            Users = new HashSet<User>();
        }
    }
}
