namespace ecotrack_backend.Dto
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateBorn { get; set; }
        public string PlaceBorn { get; set; }
    }
}
