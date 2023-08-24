using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAssemblySignalRApp.Server.Hubs
{
	public class SyncHub : Hub
	{
		public async Task SendSync(bool sync)
		{
			await Clients.All.SendAsync("ReceiveSync", sync);
		}
	}
}
