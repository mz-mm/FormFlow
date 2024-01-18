using System.Text;
using FormService.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FormService.Domain.AsyncDataService;

public class MessageBusSubscriber : BackgroundService
{
    private IEventProcessor _eventProcessor;
    private IConnection _connection;
    private IModel _channel;
    private string _queueName;

    public MessageBusSubscriber(IEventProcessor eventProcessor)
    {
        _eventProcessor = eventProcessor;
        InitialiseRabbitMQ();
    }

    private void InitialiseRabbitMQ()
    {
        var factory = new ConnectionFactory()
        {
            HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST"),
            Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT"))
        };
        
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
        _queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queue: _queueName, exchange: "trigger", routingKey: "");

        Console.WriteLine("Listing to message bus");

        _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (moduleHandle, ea) =>
        {
            Console.WriteLine("Event received");

            var body = ea.Body;
            var notificationMessage = Encoding.UTF8.GetString(body.ToArray());
            
            _eventProcessor.ProcessEvent(notificationMessage);
        };

        _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        
        return Task.CompletedTask;
    }
    
    public void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs args)
    {
        Console.WriteLine("Connection shutdown");
    } 
    
    public override void Dispose()
    {
        Console.WriteLine("Messge bus disposed");
        if ( _channel.IsOpen)
        {
            _channel.Close();
            _connection.Close();
        }
    } 

}
