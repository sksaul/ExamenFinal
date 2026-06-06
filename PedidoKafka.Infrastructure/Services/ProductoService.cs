using Microsoft.EntityFrameworkCore;
using PedidoKafka.Application.DTOs;
using PedidoKafka.Domain.Entities;
using PedidoKafka.Infrastructure.Data;

namespace PedidoKafka.Infrastructure.Services;

public class ProductoService
{
    private readonly AppDbContext _context;

    public ProductoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductoResponse> Crear(CrearProductoRequest request)
    {
        var producto = new Producto
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Precio = request.Precio,
            Stock = request.Stock,
            FechaCreacion = DateTime.UtcNow
        };

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return MapearAResponse(producto);
    }

    public async Task<List<ProductoResponse>> ObtenerTodos()
    {
        var productos = await _context.Productos.ToListAsync();
        return productos.Select(MapearAResponse).ToList();
    }

    public async Task<ProductoResponse?> ObtenerPorId(Guid id)
    {
        var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        return producto != null ? MapearAResponse(producto) : null;
    }

    public async Task<ProductoResponse?> Actualizar(Guid id, ActualizarProductoRequest request)
    {
        var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        
        if (producto == null)
            return null;

        producto.Nombre = request.Nombre;
        producto.Descripcion = request.Descripcion;
        producto.Precio = request.Precio;
        producto.Stock = request.Stock;
        producto.FechaActualizacion = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return MapearAResponse(producto);
    }

    public async Task<bool> Eliminar(Guid id)
    {
        var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        
        if (producto == null)
            return false;

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return true;
    }

    private static ProductoResponse MapearAResponse(Producto producto)
    {
        return new ProductoResponse
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            Precio = producto.Precio,
            Stock = producto.Stock,
            FechaCreacion = producto.FechaCreacion,
            FechaActualizacion = producto.FechaActualizacion
        };
    }
}
