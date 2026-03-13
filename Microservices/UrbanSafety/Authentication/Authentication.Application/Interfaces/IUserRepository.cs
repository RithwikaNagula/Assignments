using Authentication.Domain.Entities;

namespace Authentication.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByIdAsync(string id);
    Task CreateUserAsync(User user);
}
