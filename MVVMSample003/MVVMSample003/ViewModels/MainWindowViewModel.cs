using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace MVVMSample003.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        private string _sendMessage;
        public string SendMessage
        {
            get => _sendMessage;
            set
            {
                SetProperty(ref _sendMessage, value);
                SendCommand.NotifyCanExecuteChanged();
            }
        }

        private string _receiveMessage;
        public string ReceiveMessage
        {
            get => _receiveMessage;
            set => SetProperty(ref _receiveMessage, value);
        }

        public RelayCommand SendCommand { get; }

        public MainWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<string>(this, OnReceive);

            SendCommand = new RelayCommand(
                execute:() =>
                {
                    WeakReferenceMessenger.Default.Send(SendMessage);
                },
                canExecute:() =>
                {
                    return !string.IsNullOrEmpty(SendMessage);
                });
        }

        private void OnReceive(object recipient, string message)
        {
            ReceiveMessage = $"Received:{message}";
        }
    }
}
