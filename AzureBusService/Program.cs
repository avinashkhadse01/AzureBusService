// See https://aka.ms/new-console-template for more information
/*Console.WriteLine("Hello, World!");
Console.ReadLine();*/

using AzureBusService;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ServiceBusConfiguration();
        var serviceBusClient = new ServiceBusClient(config);

        await serviceBusClient.SendMessage("Message from the sender");

        await serviceBusClient.ReceiveMessage();
    }
}
