
using Microsoft.AspNetCore.SignalR.Client;
using ReactiveUI;
using System.Windows.Input;

namespace AvaloniaClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private HubConnection? hubConnection;
        public string Greeting => "Welcome to Avalonia!";

        public string UserName { get; set; }

        public string Message { get; set; }

        public ICommand SendCommand { get; set; }

        public MainWindowViewModel()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl(@"https://localhost:7248/dthub")
            .Build();
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";
            });
            hubConnection.StartAsync();
            SendCommand = ReactiveCommand.Create(async () => {
                if (hubConnection is not null)
                {
                    await hubConnection.SendAsync("SendMessage", UserName, Message);
                }
            });
        }
    }
}