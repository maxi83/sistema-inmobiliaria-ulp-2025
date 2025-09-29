using sistema_inmobiliaria_ulp_2025.Data;
using sistema_inmobiliaria_ulp_2025.Models;
using sistema_inmobiliaria_ulp_2025.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sistema_inmobiliaria_ulp_2025.Repositories.Implementations;

public class InmuebleRepository : IInmuebleRepository
{
    private readonly AppCntxt _context;
    private readonly DbSet<Inmueble> _inmuebles;

    public InmuebleRepository(AppCntxt context)
    {
        _context = context;
        _inmuebles = context.Inmuebles;
    }

    public async Task<IEnumerable<Inmueble>> GetAllAsync() =>
        await _inmuebles.ToListAsync();

    public async Task<IEnumerable<Inmueble>> GetByPropietarioIdAsync(int propietarioId) =>
        await _inmuebles.Where(i => i.PropietarioId == propietarioId).ToListAsync();

    public async Task<IEnumerable<Inmueble>> GetByDisponibilidadAsync(Disponibilidad disponibilidad) =>
        await _inmuebles.Where(i => i.Disponibilidad == disponibilidad).ToListAsync();

    public async Task<IEnumerable<Inmueble>> GetByIdsAsync(IEnumerable<int> ids) =>
        await _inmuebles.Where(i => ids.Contains(i.InmuebleId)).ToListAsync();

    public async Task<Inmueble?> GetByIdAsync(int id) =>
        await _inmuebles.FindAsync(id);

    public async Task<Inmueble?> GetWithPropietarioAsync(int id) =>
        await _inmuebles.Include(i => i.Propietario).FirstOrDefaultAsync(i => i.Id == id);

    public async Task AddAsync(Inmueble inmueble) =>
        await _inmuebles.AddAsync(inmueble);

    public void Update(Inmueble inmueble) =>
        _inmuebles.Update(inmueble);

    public void Delete(Inmueble inmueble) =>
        _inmuebles.Remove(inmueble);

    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();

    public async Task<bool> ExistsAsync(int id) =>
        await _inmuebles.AnyAsync(i => i.InmuebleId == id);
}