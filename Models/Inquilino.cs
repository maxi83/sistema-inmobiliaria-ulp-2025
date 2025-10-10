using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sistema_inmobiliaria_ulp_2025.Models;

public class Inquilino : DatosPersonales
{
    public Inquilino() { }

    [Key]
    public int Id { get; set; }

    [InverseProperty("Inquilino")]
    public virtual required List<Contrato>? Contratos { get; set; }

}

 