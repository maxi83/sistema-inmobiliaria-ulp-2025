using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema_inmobiliaria_ulp_2025.Models;

public class Propietario : DatosPersonales
{
    public Propietario() { }
    [Key]
    private int Id { get; set; }
    [InverseProperty("Propietario")]
    public virtual required List<Inmueble>? Inmueble { get; set; }
}