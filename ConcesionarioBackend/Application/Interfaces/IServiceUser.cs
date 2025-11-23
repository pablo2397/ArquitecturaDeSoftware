using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IServiceUser
    {
        Task<User> CreateUserAsync(User user);
        Task<User> LoginAsync(UserDto userDto);
        Task<User> UpdateAsync(User user);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> GetId(int id);
        Task DeleteAsync(int id);
    }
}
