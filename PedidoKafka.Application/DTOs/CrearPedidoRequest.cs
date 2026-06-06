namespace PedidoKafka.Application.DTOs;

public class CrearPedidoRequest
{
    public string Cliente { get; set; } = string.Empty;

    public decimal Total { get; set; }
}