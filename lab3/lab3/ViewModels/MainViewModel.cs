using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace lab3;
internal class MainViewModel : INotifyPropertyChanged
{

    private readonly EventManager _eventManager;
    private string _message;

    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged(nameof(Message));
        }
    }

    public RelayCommand ButtonCommand { get; }

    public MainViewModel()
    {
        _eventManager = new EventManager();
        _eventManager.OnNotify += HandleNotification;

        ButtonCommand = new RelayCommand(() => _eventManager.TriggerEvent("¡Evento disparado!"));
    }

    private void HandleNotification(string message)
    {
        Message = message;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
