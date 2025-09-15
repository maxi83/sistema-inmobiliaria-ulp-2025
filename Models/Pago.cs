using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sistema_inmobiliaria_ulp_2025.Models;


public class Pago
{
    public Pago() { }

    [Key]
    public int PagoId { get; set; }
    public int NoPago { get; set; }
    public DateOnly Fecha { get; set; }
    public decimal Importe { get; set; }

    [ForeignKey("Contrato")]
    public int ContratoId { get; set; }
    public virtual required Contrato? Contrato { get; set; }

    [ForeignKey("Inquilino")]
    public int InquilinoId { get; set; }
    public virtual required Inquilino? Inquilino { get; set; }
};
