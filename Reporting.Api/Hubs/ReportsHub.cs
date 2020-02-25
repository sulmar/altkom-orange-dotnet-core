using Microsoft.AspNetCore.SignalR;
using Reporting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Api.Hubs
{
    
    public class ReportsHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            // return this.Groups.AddToGroupAsync(Context.ConnectionId, "Orange");            
            return base.OnConnectedAsync();
        }

        public async Task SendReport(Report report)
        {
            await this.Clients.All.SendAsync("YouHaveGotReport", report);

            // await this.Clients.Others.SendAsync("YouHaveGotReport", report);

            // await this.Clients.Groups("Orange").SendAsync("YouHaveGotReport", report);
        }

        public async Task Ping()
        {
            await Clients.Caller.SendAsync("Pong");
        }
    }
}
