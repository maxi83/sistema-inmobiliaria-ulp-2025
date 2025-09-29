using System.Collections.Generic;
using System.Threading.Tasks;
using sistema_inmobiliaria_ulp_2025.Data;
using sistema_inmobiliaria_ulp_2025.Models;
using sistema_inmobiliaria_ulp_2025.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace sistema_inmobiliaria_ulp_2025.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppCntxt _context;
    private readonly DbSet<User> _users;

    public UserRepository(AppCntxt context)
    {
        _context = context;
        _users = context.Set<User>();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _users.FindAsync(id);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
    }

    public void Update(User user)
    {
        _users.Update(user);
    }

    public void Delete(User user)
    {
        _users.Remove(user);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
