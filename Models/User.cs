using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using MySqlConnector;
namespace sistema_inmobiliaria_ulp_2025.Models;

public class User
{
    public User() { }
    public User(MySqlDataReader reader)
    {
        Id = reader.GetInt32("Id");
        Username = reader.GetString("Username");
        Password = reader.GetString("Password");
        Rol = reader.GetString("Rol");
    }

    public User(int id, string username, string password, string rol)
    {
        Id = id;
        Username = username;
        Password = password;
        Rol = rol;
    }

    [Key]
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Rol { get; set; } = "";
}