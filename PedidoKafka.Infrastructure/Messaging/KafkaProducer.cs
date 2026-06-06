using Confluent.Kafka;
using System.Text.Json;
using PedidoKafka.Domain.Entities;

namespace PedidoKafka.Infrastructure.Messaging;

public class KafkaProducer
{
    private readonly IProducer<Null, string> _producer;

    public KafkaProducer()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        _producer = new ProducerBuilder<Null, string>(config)
            .Build();
    }

    public async Task PublicarAsync(PedidoEvent pedido)
    {
        var mensaje = JsonSerializer.Serialize(pedido);

        await _producer.ProduceAsync(
            "pedidos",
            new Message<Null, string>
            {
                Value = mensaje
            });

        Console.WriteLine($"Pedido enviado: {mensaje}");
    }
}