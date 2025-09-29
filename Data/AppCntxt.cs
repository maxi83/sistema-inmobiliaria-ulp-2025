using sistema_inmobiliaria_ulp_2025.Models;
using Microsoft.EntityFrameworkCore;

namespace sistema_inmobiliaria_ulp_2025.Data;

public partial class AppCntxt : DbContext
{
    public AppCntxt() { }

    public AppCntxt(DbContextOptions<AppCntxt> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=Inmobiliaria.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(p => p.Username).IsUnique();
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Inquilino> Inquilinos { get; set; } = default!;

    public DbSet<Propietario> Propietarios { get; set; } = default!;

    public DbSet<Inmueble> Inmuebles { get; set; } = default!;

    public DbSet<Contrato> Contratos { get; set; } = default!;

    public DbSet<Pago> Pagos { get; set; } = default!;
}
