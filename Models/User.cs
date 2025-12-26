namespace ecotrack_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateBorn { get; set; }
        public string PlaceBorn { get; set; }
        public ICollection<ecotrack_backend.Models.Task> Tasks { get; set; } = new List<ecotrack_backend.Models.Task>();
    }
}
