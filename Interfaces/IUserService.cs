using ecotrack_backend.Dto;

namespace ecotrack_backend.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResponse> login(LoginRequest request);
        public Task<RegisterResponse> register(RegisterRequest request);
    }
}
