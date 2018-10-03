using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Manager.Common.Utilities;
using Manager.Domain;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace Manager.Data
{
    public class EventBus : IEventBus, IDisposable
    {
        private const string ExchangeName = "EventBus";

        private readonly RabbitMQConnection connection;

        //private readonly IEventBusSubscriptionsManager _subsManager;
        //private readonly ILifetimeScope _autofac;
        private readonly string AUTOFAC_SCOPE_NAME = "eshop_event_bus";

        private readonly int retryCount;

        private IModel consumerChannel;
        private string _queueName;

        public void Publish(IDomainEvent domainEvent)
        {
            if (!connection.IsConnected)
                connection.TryConnect();

            var policy = Policy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    LogUtility.Warn(ex.ToString());
                });

            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(ExchangeName, "direct");

                var eventName = domainEvent.GetType().Name;
                var message = JsonUtility.Serialize(domainEvent);
                var body = Encoding.UTF8.GetBytes(message);

                policy.Execute(() =>
                {
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;
                    channel.BasicPublish(ExchangeName, eventName, true, properties, body);
                });
            }
        }

        public void Dispose()
        {
            if (consumerChannel != null)
                consumerChannel.Dispose();

            //_subsManager.Clear();
        }
    }
}