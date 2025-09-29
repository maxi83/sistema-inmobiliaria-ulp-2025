using System.Collections.Generic;
using System.Threading.Tasks;
using sistema_inmobiliaria_ulp_2025.Data;
using sistema_inmobiliaria_ulp_2025.Models;
using sistema_inmobiliaria_ulp_2025.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace sistema_inmobiliaria_ulp_2025.Repositories.Implementations;

public class ContratoRepository : IContratoRepository
{
    private readonly AppCntxt _context;
    private readonly DbSet<Contrato> _contratos;

    public ContratoRepository(AppCntxt context)
    {
        _context = context;
        _contratos = context.Contratos;
    }

    public async Task<IEnumerable<Contrato>> GetAllAsync() => await _contratos.ToListAsync();

    public async Task<IEnumerable<Contrato>> GetByInmuebleIdAsync(int inmuebleId) =>
        await _contratos.Where(c => c.InmuebleId == inmuebleId).ToListAsync();

    public async Task<IEnumerable<Contrato>> GetByRangoFechasAsync(
        DateOnly desde,
        DateOnly hasta
    ) => await _contratos.Where(c => c.Desde >= desde && c.Hasta <= hasta).ToListAsync();

    public async Task<Contrato?> GetByIdAsync(int id) =>
        await _contratos.FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Contrato contrato) => await _contratos.AddAsync(contrato);

    public void Update(Contrato contrato) => _contratos.Update(contrato);

    public void Delete(Contrato contrato) => _contratos.Remove(contrato);

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public async Task<bool> ExistsAsync(int id) => await _contratos.AnyAsync(c => c.Id == id);
}
