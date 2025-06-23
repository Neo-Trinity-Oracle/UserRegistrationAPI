using UserRegistrationApi.Models;

public interface IUserRepository
{
    Task<User> GetByUsernameAsync(string username);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<bool> ExistsByUsernameAsync(string username);
    Task SaveChangesAsync();
}
