using System;
using System.IO;
using System.Net.Sockets;
using Manager.Common.Utilities;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Manager.Data
{
    public class RabbitMQConnection
    {
        private readonly IConnectionFactory connectionFactory;
        private readonly int retryCount;
        private IConnection connection;
        private bool isDisposed;
        private object connectLock = new object();

        public RabbitMQConnection(IConnectionFactory connectionFactory, int retryCount = 5)
        {
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            this.retryCount = retryCount;
        }

        public bool IsConnected
        {
            get
            {
                return connection != null && connection.IsOpen && !isDisposed;
            }
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("No RabbitMQ connections are available to perform this action");
            }

            return connection.CreateModel();
        }

        public void Dispose()
        {
            if (isDisposed)
                return;

            isDisposed = true;

            try
            {
                connection.Dispose();
            }
            catch (IOException ex)
            {
                LogUtility.Fatal(ex.ToString());
            }
        }

        public bool TryConnect()
        {
            LogUtility.Info("RabbitMQ Client is trying to connect");

            lock (connectLock)
            {
                Policy.Handle<SocketException>()
                    .Or<BrokerUnreachableException>()
                    .WaitAndRetry(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                        LogUtility.Warn(ex.ToString());
                    })
                    .Execute(() =>
                    {
                        connection = connectionFactory.CreateConnection();
                    });

                if (IsConnected)
                {
                    connection.ConnectionShutdown += OnConnectionShutdown;
                    connection.CallbackException += OnCallbackException;
                    connection.ConnectionBlocked += OnConnectionBlocked;
                    LogUtility.Info($"RabbitMQ persistent connection acquired a connection {connection.Endpoint.HostName} and is subscribed to failure events");

                    return true;
                }
                else
                {
                    LogUtility.Fatal("RabbitMQ connections could not be created and opened");

                    return false;
                }
            }
        }

        private void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            if (isDisposed)
                return;

            LogUtility.Warn("A RabbitMQ connection is shutdown. Trying to re-connect...");
            TryConnect();
        }

        private void OnCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            if (isDisposed)
                return;

            LogUtility.Warn("A RabbitMQ connection throw exception. Trying to re-connect...");
            TryConnect();
        }

        private void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            if (isDisposed)
                return;

            LogUtility.Warn("A RabbitMQ connection is on shutdown. Trying to re-connect...");
            TryConnect();
        }
    }
}