using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistema_inmobiliaria_ulp_2025.Models;

public class Inmueble
{
    public Inmueble() { }
    [Key]
    public int Id { get; set; }
    [ForeignKey("Propietario")]
    public int PropietarioId { get; set; }
    public virtual required Propietario? Propietario { get; set; }
    public string Direccion { get; set; } = "";
    public Uso Uso { get; set; }
    public Tipo Tipo { get; set; }
    public int NumeroAmbientes { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public decimal Precio { get; set; }
    public Disponibilidad Disponibilidad { get; set; }
 }
public enum Uso
{
    COMERCIAL,
    RESIDENCIA,
}
public enum Tipo
{
    LOCAL,
    DEPOSITO,
    CASA,
    DEPARTAMENTO,
}
public enum Disponibilidad
{
    OCUPADO,
    SUSPENDIDO,
    DESOCUPADO,
}