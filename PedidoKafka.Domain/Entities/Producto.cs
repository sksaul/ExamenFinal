namespace PedidoKafka.Domain.Entities;

public class Producto
{
    public Guid Id { get; set; }
    
    public string Nombre { get; set; } = string.Empty;
    
    public string Descripcion { get; set; } = string.Empty;
    
    public decimal Precio { get; set; }
    
    public int Stock { get; set; }
    
    public DateTime FechaCreacion { get; set; }
    
    public DateTime? FechaActualizacion { get; set; }
}
