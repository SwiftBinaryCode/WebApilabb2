namespace WebApplicationlabb.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; } = string.Empty;
        public virtual ICollection<Course> Courses { get; set; }

        public User()
        {
            Courses = new List<Course>();
        }
    }
}
