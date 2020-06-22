using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWeb.Server.Services;
using Microsoft.AspNetCore.SignalR;

namespace BlazorWeb.Server.Hubs
{
    public class ClientHub : Hub
    {
        private readonly TimerService _timerService;

        public ClientHub(TimerService timerService) => _timerService = timerService;

        public async Task Start() => await Task.Run(() => _timerService.Start());

        public async Task Stop() => await Task.Run(() => _timerService.Stop());
    }
}
