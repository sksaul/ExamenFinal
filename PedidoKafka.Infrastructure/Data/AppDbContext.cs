using Microsoft.EntityFrameworkCore;
using PedidoKafka.Domain.Entities;

namespace PedidoKafka.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.Precio).HasPrecision(18, 2);
            entity.Property(e => e.Stock).IsRequired();
            entity.Property(e => e.FechaCreacion).IsRequired();
            entity.Property(e => e.FechaActualizacion).IsRequired(false);
        });
    }
}
