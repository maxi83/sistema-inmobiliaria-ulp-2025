using sistema_inmobiliaria_ulp_2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sistema_inmobiliaria_ulp_2025.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
    void Update(User user);
    void Delete(User user);
    Task SaveAsync();
}