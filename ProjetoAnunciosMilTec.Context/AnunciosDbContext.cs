using Microsoft.EntityFrameworkCore;
using ProjetoAnunciosMilTec.Entity.Models;
using System.Reflection;

namespace ProjetoAnunciosMilTec.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Produto> Produtos { get; set; } = null!;
    public DbSet<Servico> Servicos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}