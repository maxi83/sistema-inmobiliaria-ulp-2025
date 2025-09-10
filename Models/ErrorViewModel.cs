/*namespace es nombre asignado para un grupo de archivos.
es un nombre de espcio que funciona como contenedor absracto que agrupa 
identificadores únicos como clases, funciones y variables permitiendo que
 el mismo nombre se utilicen en diferentes contextos sin conflictos*/
 namespace sistema_inmobiliaria_ulp_2025.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
