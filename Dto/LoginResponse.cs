namespace ecotrack_backend.Dto
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
