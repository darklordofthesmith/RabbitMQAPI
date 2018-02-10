using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQAPI.Services
{
    public class Send
    {
        public Send(string message)
        {
            //open connection

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "SimpleMessage",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange:"",
                                     routingKey: "SimpleMessage",
                                     basicProperties: null,
                                     body: body);                      
            }
        }
    }
}
