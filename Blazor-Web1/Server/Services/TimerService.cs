
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using BlazorWeb.Server.Hubs;

namespace BlazorWeb.Server.Services
{
    public class TimerService
    {
        private Timer _timer;
        private IHubContext<ClientHub> _hub;

        public TimerService(IHubContext<ClientHub> hub)
        {
            if (_timer == null)
            {
                _timer = new Timer(1000);
                _timer.Elapsed += Timer_Elapsed;
                _hub = hub;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_hub != null)
                _hub.Clients.All.SendAsync("ReceiveTime", DateTime.Now.ToString());
        }

        public void Start() => _timer.Start();

        public void Stop()
        {
            _timer.Stop();

            if (_hub != null)
                _hub.Clients.All.SendAsync("StopTime");
        }
    }
}
