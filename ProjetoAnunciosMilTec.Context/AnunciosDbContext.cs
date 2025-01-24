using Microsoft.EntityFrameworkCore;
using ProjetoAnunciosMilTec.Entity.Models;
using System.Reflection;

namespace ProjetoAnunciosMilTec.Context;

public class AnunciosDbContext(DbContextOptions<AnunciosDbContext> options) : DbContext(options)
{
    public DbSet<Produto> Produtos { get; set; } = null!;
    public DbSet<Servico> Servicos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}