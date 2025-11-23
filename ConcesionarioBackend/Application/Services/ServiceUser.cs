using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.DataProtection;

namespace Application.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IDataProtector _protector;

        public ServiceUser(IRepositoryUser repositoryUser, IDataProtectionProvider provider)
        {
            _repositoryUser = repositoryUser;
            _protector = provider.CreateProtector("password");
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var passwordEncryption = _protector.Protect(user.Password);
            user.Password = passwordEncryption;
            return await _repositoryUser.CreateUserAsync(user);
        }

        public async Task<User> LoginAsync(UserDto userDto)
        {
            var username = await _repositoryUser.GetUsernameAsync(userDto.Username);
            if (username == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var passwordDecoded = _protector.Unprotect(username.Password);

            if (passwordDecoded != userDto.Password)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            return username;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var passwordEncryption = _protector.Protect(user.Password);
            user.Password = passwordEncryption;
            return await _repositoryUser.UpdateUserAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
            => await _repositoryUser.GetAllUserAsync();

        public async Task<User?> GetId(int id)
            => await _repositoryUser.GetId(id);

        public async Task DeleteAsync(int id)
            => await _repositoryUser.DeleteAsync(id);
    }
}
