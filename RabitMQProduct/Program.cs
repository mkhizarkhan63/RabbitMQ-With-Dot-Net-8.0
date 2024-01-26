////Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
//using RabbitMQ.Client.Events;
//using RabbitMQ.Client;
//using System.Text;
//using System.Runtime.CompilerServices;

//var factory = new ConnectionFactory
//{
//    HostName = "localhost"
//};
////Create the RabbitMQ connection using connection factory details as i mentioned above
//var connection = factory.CreateConnection();
////Here we create channel with session and model
//using
//var channel = connection.CreateModel();
////declare the queue after mentioning name and a few property related to that
//channel.QueueDeclare("product", exclusive: false);
////Set Event object which listen message from chanel which is sent by producer
//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, eventArgs) => {
//    var body = eventArgs.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine($"Product message received: {message}");
//};
////read the message
//channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
//Console.ReadKey();



using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

try
{
    using (var connection = factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
        // Declare the exchange
        channel.ExchangeDeclare("abc", ExchangeType.Direct);

        // Declare the queue
        channel.QueueDeclare("product", exclusive: false);

        // Bind the queue to the exchange with a routing key
        channel.QueueBind(queue: "product", exchange: "abc", routingKey: "product");

        // Set up the consumer
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, eventArgs) => {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Product message received: {message}");
        };

        // Start consuming messages
        channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);

        Console.WriteLine("Press [Enter] to exit.");
        Console.ReadLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
