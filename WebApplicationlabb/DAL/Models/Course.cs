namespace WebApplicationlabb.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Length { get; set; }
        public string Level { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; }

        public Course()
        {
            Users = new List<User>();
        }
    }
}
