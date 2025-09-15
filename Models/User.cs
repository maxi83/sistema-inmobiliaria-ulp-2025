using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models;

public class User
{
    public User() { }

    public User(string username, string password, string rol)
    {
        Username = username;
        Password = password;
        Rol = rol;
    }

    [Key]
    public int UserId { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Rol { get; set; } = "";
}