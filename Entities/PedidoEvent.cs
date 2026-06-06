namespace PedidoKafka.Domain.Entities;

public class PedidoEvent
{
    public Guid Id { get; set; }

    public string Cliente { get; set; } = string.Empty;

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }
}