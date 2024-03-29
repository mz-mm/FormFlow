using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using WorkspaceService.Domain.Dtos;

namespace WorkspaceService.Domain.AsyncDataService;

public class MessageBusClient : IMessageBusClient
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public MessageBusClient(IConfiguration configuration, bool isProduction)
    {
        var factory = new ConnectionFactory()
        {
            HostName = isProduction ? Environment.GetEnvironmentVariable("RABBITMQ_HOST") : configuration["RabbitMQHost"],
            Port = isProduction ? Convert.ToInt32(Environment.GetEnvironmentVariable("RABBITMQ_PORT")) : Convert.ToInt32(configuration["RabbitMQPort"])
        }; 
        try
        {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error Connecting to Message bus: {exception.Message}");
        }
    }

    public void PublishNewWorkspace(PublishWorkspaceDto publishWorkspaceDto)
    {
        var message = JsonSerializer.Serialize(publishWorkspaceDto);

        if (_connection.IsOpen)
        {
            Console.WriteLine("RabbitMQ connection open, sending message");
            SendMessage(message);
        }
        else
        {
            Console.WriteLine("RabbitMQ connection closes");
        }
    }

    private void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);
        Console.WriteLine($"Send {message}");
    }

    public void Dispose()
    {
        Console.WriteLine("Messge bus disposed");
        if ( _channel.IsOpen)
        {
            _channel.Close();
            _connection.Close();
        }
    }

    public void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs args)
    {
        Console.WriteLine("Connection shutdown");
    }
}
