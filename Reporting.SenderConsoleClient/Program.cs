using Microsoft.AspNetCore.SignalR.Client;
using Reporting.Domain;
using System;
using System.Threading.Tasks;

namespace Reporting.SenderConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Signal-R Sender!");

            string url = "https://localhost:5001/signalr/reporting";

            // dotnet add package Microsoft.AspNetCore.SignalR.Client

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            Console.WriteLine("Connecting...");

            await connection.StartAsync();

            Console.WriteLine("Connected.");

            int i = 1;

            while (true)
            {
                
                Report report = new Report { Title = $"Report {i++}", Content = "Hello World!" };

                await connection.SendAsync("SendReport", report);

                Console.WriteLine("Sent.");
                
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


        }
    }
}
