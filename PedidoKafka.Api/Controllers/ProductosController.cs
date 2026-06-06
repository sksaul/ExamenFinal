using Microsoft.AspNetCore.Mvc;
using PedidoKafka.Application.DTOs;
using PedidoKafka.Infrastructure.Services;

namespace PedidoKafka.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoService _productoService;

    public ProductosController(ProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearProductoRequest request)
    {
        var producto = await _productoService.Crear(request);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var productos = await _productoService.ObtenerTodos();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(Guid id)
    {
        var producto = await _productoService.ObtenerPorId(id);
        
        if (producto == null)
            return NotFound();
        
        return Ok(producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(Guid id, ActualizarProductoRequest request)
    {
        var producto = await _productoService.Actualizar(id, request);
        
        if (producto == null)
            return NotFound();
        
        return Ok(producto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(Guid id)
    {
        var resultado = await _productoService.Eliminar(id);
        
        if (!resultado)
            return NotFound();
        
        return NoContent();
    }
}
