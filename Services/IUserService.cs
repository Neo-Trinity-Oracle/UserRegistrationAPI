using UserRegistrationApi.Models;

namespace UserRegistrationApi.Services
{
    public interface IUserService
    {
        public Task<User> Register(RegisterRequest request);
        public Task<User> Login(LoginRequest request);
        public Task<User> Update(UpdateRequest request);
    }
}