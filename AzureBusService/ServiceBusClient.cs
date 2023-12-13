using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBusService
{
    public class ServiceBusClient
    {
        private readonly IQueueClient _queueClient;
        
        public ServiceBusClient(ServiceBusConfiguration configuration)
        {
            _queueClient = new QueueClient(configuration.ConnString, configuration.QueueName);
        }

        public async Task SendMessage(string message)
        {
            var fullMessage = new Message(Encoding.UTF8.GetBytes(message));
            await _queueClient.SendAsync(fullMessage);
        }

        public async Task ReceiveMessage()
        {
            var messageHandler = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessage, messageHandler);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            await _queueClient.CloseAsync();
        }

        private async Task ProcessMessage(Message message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Received message: {Encoding.UTF8.GetString(message.Body)}");

            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message exception: {exceptionReceivedEventArgs.Exception}");

            return Task.CompletedTask;
        }
    }
}
