using sistema_inmobiliaria_ulp_2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sistema_inmobiliaria_ulp_2025.Repositories.Interfaces;

public interface IInmuebleRepository
{
    Task<IEnumerable<Inmueble>> GetAllAsync();
    Task<IEnumerable<Inmueble>> GetByPropietarioIdAsync(int propietarioId);
    Task<IEnumerable<Inmueble>> GetByDisponibilidadAsync(Disponibilidad disponibilidad);
    Task<IEnumerable<Inmueble>> GetByIdsAsync(IEnumerable<int> ids);
    Task<Inmueble?> GetByIdAsync(int id);
    Task<Inmueble?> GetWithPropietarioAsync(int id);
    Task AddAsync(Inmueble inmueble);
    void Update(Inmueble inmueble);
    void Delete(Inmueble inmueble);
    Task SaveAsync();
    Task<bool> ExistsAsync(int id);
}