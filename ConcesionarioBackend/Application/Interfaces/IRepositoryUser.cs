using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRepositoryUser
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUsernameAsync(string username);
        Task<User?> UpdateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> GetId(int id);
        Task DeleteAsync(int id);
    }
}
