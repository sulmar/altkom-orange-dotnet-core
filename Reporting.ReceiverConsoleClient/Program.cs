using Microsoft.AspNetCore.SignalR.Client;
using Reporting.Domain;
using System;
using System.Threading.Tasks;

namespace Reporting.ReceiverConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Signal-R Receiver!");

            string url = "https://localhost:5001/signalr/reporting";

            // dotnet add package Microsoft.AspNetCore.SignalR.Client

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            Console.WriteLine("Connecting...");

            await connection.StartAsync();

            Console.WriteLine("Connected.");

            connection.On<Report>("YouHaveGotReport",
                report => Console.WriteLine($"Received {report.Title} {report.Content}"));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
