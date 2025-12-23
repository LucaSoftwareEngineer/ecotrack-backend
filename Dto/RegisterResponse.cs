namespace ecotrack_backend.Dto
{
    public class RegisterResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateBorn { get; set; }
        public string PlaceBorn { get; set; }
    }
}
