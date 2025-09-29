using sistema_inmobiliaria_ulp_2025.Models;

namespace sistema_inmobiliaria_ulp_2025.Repositories.Interfaces;

public interface IContratoRepository
{
    Task<IEnumerable<Contrato>> GetAllAsync();
    Task<IEnumerable<Contrato>> GetByInmuebleIdAsync(int inmuebleId);
    Task<IEnumerable<Contrato>> GetByRangoFechasAsync(DateOnly desde, DateOnly hasta);
    Task<Contrato?> GetByIdAsync(int id);
    Task AddAsync(Contrato contrato);
    void Update(Contrato contrato);
    void Delete(Contrato contrato);
    Task SaveAsync();
    Task<bool> ExistsAsync(int id);
}
