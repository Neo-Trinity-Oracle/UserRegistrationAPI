using UserRegistrationApi.Exceptions;
using UserRegistrationApi.Models;
using UserRegistrationApi.Utils;

namespace UserRegistrationApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly HashPassword _hashPassword;
        public UserService(IUserRepository userRepository, HashPassword hashPassword)
        {
            _userRepository = userRepository;
            _hashPassword = hashPassword;
        }
        public async Task<User> Register(RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Password))
                throw new AppException("Password cannot be empty");
            if (await _userRepository.ExistsByUsernameAsync(request.Username))
                throw new AppException("Username is already taken");
            var hashedPassword = _hashPassword.Hash(request.Password);
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                PasswordHash = hashedPassword
            };
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }
        public async Task<User> Login(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                throw new AppException("Username and password are required");
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null || user.PasswordHash != _hashPassword.Hash(request.Password))
                throw new NotFoundException("Invalid username or password");
            return user;
        }
        public async Task<User> Update(UpdateRequest request)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null)
                throw new NotFoundException("User not found");
            if (user.PasswordHash != _hashPassword.Hash(request.OldPassword))
                throw new AppException("Old password does not match");
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PasswordHash = _hashPassword.Hash(request.NewPassword);
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }
    }
}
