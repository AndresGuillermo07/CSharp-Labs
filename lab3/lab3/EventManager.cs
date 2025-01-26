using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3;
internal class EventManager
{
    public delegate void Notify(string message);
    public event Notify OnNotify;

    public void TriggerEvent(string message)
    {
        OnNotify?.Invoke(message);
    }
}
