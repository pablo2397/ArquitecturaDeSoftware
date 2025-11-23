using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly ConcesionarioContext _concesionarioContext;
        public RepositoryUser(ConcesionarioContext concesionarioContext)
        {
            _concesionarioContext = concesionarioContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _concesionarioContext.Add(user);
            await _concesionarioContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUsernameAsync(string username)
        {
            return await _concesionarioContext.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var id = GetEntityKeyValue(user);

            if (id == null)
                throw new InvalidOperationException($"La entidad {typeof(User).Name} no tiene un ID válido");

            // Busca en base de datos la entidad actual
            var exists = await _concesionarioContext.Set<User>().FindAsync(id);

            if (exists == null)
                return null;

            // Copia los nuevos valores sin duplicar el tracking
            _concesionarioContext.Entry(exists).CurrentValues.SetValues(user);
            await _concesionarioContext.SaveChangesAsync();

            return exists;
        }

        private object? GetEntityKeyValue(User user)
        {
            var keyProperty = typeof(User)
                .GetProperties()
                .FirstOrDefault(p => p.Name.StartsWith("ID", StringComparison.OrdinalIgnoreCase));

            if (keyProperty == null)
                throw new InvalidOperationException($"No se encontró propiedad de clave primaria en la entidad {typeof(User).Name}");

            return keyProperty.GetValue(user);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        => await _concesionarioContext.Users.ToListAsync();

        public async Task<User?> GetId(int id)
            => await _concesionarioContext.Users.FindAsync(id);

        public async Task DeleteAsync(int id)
        {
            var user = await _concesionarioContext.Users.FindAsync(id);

            if (user != null)
            {
                _concesionarioContext.Remove(user);
                await _concesionarioContext.SaveChangesAsync();

            }
        }
    }
}
