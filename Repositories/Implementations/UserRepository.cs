using sistema_inmobiliaria_ulp_2025.Models;
using sistema_inmobiliaria_ulp_2025.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace sistema_inmobiliaria_ulp_2025.Repositories.Implementations;

public class UserRepository(IConfiguration configuration) : IUserRepository
{
    private readonly string _connectionString =
        configuration.GetConnectionString("MariaDBConnection") ?? "";

    public async Task<User?> GetByIdAsync(int id)
    {
        string sql = "SELECT * FROM users WHERE Id = @Id;";
        await using MySqlConnection conn = new(_connectionString);
        await using MySqlCommand cmd = new(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        await conn.OpenAsync();
        await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();
        return await reader.ReadAsync() ? new User(reader) : null;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        string sql = "SELECT * FROM users WHERE Username = @Username;";
        await using MySqlConnection conn = new(_connectionString);
        await using MySqlCommand cmd = new(sql, conn);
        cmd.Parameters.AddWithValue("@Username", username);
        await conn.OpenAsync();
        await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();
        return await reader.ReadAsync() ? new User(reader) : null;
    }

    public async Task AddAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        const string sql =
            @"
            INSERT INTO Users (Username, Password, Rol)
            VALUES (@Username, @Password, @Rol);
            SELECT LAST_INSERT_ID();";
        await using MySqlConnection conn = new(_connectionString);
        await using MySqlCommand cmd = new(sql, conn);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        cmd.Parameters.AddWithValue("@Username", user.Username);
        cmd.Parameters.AddWithValue("@Password", user.Password);
        cmd.Parameters.AddWithValue("@Rol", user.Rol);

        await conn.OpenAsync();
        object? lastIdObj = await cmd.ExecuteScalarAsync();
        if (lastIdObj != null && lastIdObj != DBNull.Value)
            user.Id = Convert.ToInt32(lastIdObj);
    }

    public void Update(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        const string sql =
            @"
            UPDATE Users
            SET Username = @Username,
                Password = @Password,
                Rol = @Rol,
            WHERE Id = @Id";
        using MySqlConnection conn = new(_connectionString);
        using MySqlCommand cmd = new(sql, conn);
        cmd.Parameters.AddWithValue("@Username", user.Username);
        cmd.Parameters.AddWithValue("@Password", user.Password);
        cmd.Parameters.AddWithValue("@Rol", user.Rol);
        cmd.Parameters.AddWithValue("@Id", user.Id);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void Delete(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        const string sql = "DELETE FROM Users WHERE Id = @Id";
        using MySqlConnection conn = new(_connectionString);
        using MySqlCommand cmd = new(sql, conn);
        cmd.Parameters.AddWithValue("@Id", user.Id);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public async Task SaveAsync()
    {
        await Task.CompletedTask;
    }
}
