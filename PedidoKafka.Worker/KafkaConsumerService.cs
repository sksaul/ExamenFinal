using Confluent.Kafka;

namespace PedidoKafka.Worker;

public class KafkaConsumerService : BackgroundService
{
    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "pedidos-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer =
            new ConsumerBuilder<Ignore, string>(config)
            .Build();

        consumer.Subscribe("pedidos");

        Console.WriteLine("Escuchando mensajes...");

        while (!stoppingToken.IsCancellationRequested)
        {
            var result = consumer.Consume(stoppingToken);

            Console.WriteLine(
                $"Mensaje recibido: {result.Message.Value}");
        }

        await Task.CompletedTask;
    }
}