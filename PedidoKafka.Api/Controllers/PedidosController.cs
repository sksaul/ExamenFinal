using Microsoft.AspNetCore.Mvc;
using PedidoKafka.Application.DTOs;
using PedidoKafka.Domain.Entities;
using PedidoKafka.Infrastructure.Messaging;

namespace PedidoKafka.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly KafkaProducer _producer;

    public PedidosController(KafkaProducer producer)
    {
        _producer = producer;
    }

    [HttpPost]
    public async Task<IActionResult> Crear(
        CrearPedidoRequest request)
    {
        var pedido = new PedidoEvent
        {
            Id = Guid.NewGuid(),
            Cliente = request.Cliente,
            Total = request.Total,
            Fecha = DateTime.UtcNow
        };

        await _producer.PublicarAsync(pedido);

        return Ok(new
        {
            Mensaje = "Pedido enviado a Kafka"
        });
    }
}