using Microsoft.EntityFrameworkCore;
using ProjetosDB.Models;

namespace ProjetosDB.Data;

public class AppDbContext : DbContext
{
    // Adicionado o 'public' aqui!
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Defini o esquema padrão para as tabelas
        modelBuilder.HasDefaultSchema("Gerenciador");
    }
}