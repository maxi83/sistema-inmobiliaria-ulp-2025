using System.ComponentModel.DataAnnotations;

namespace sistema_inmobiliaria_ulp_2025.Models;

public class User
{
    public User() { }

    [Key]
    public int UserId { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Rol { get; set; } = "";
}