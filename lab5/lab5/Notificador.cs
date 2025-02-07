using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5;
internal class Notificador
{
    private List<Func<string, Task>> observadores = new List<Func<string, Task>>();

    public void Suscribir(Func<string, Task> observador)
    {
        observadores.Add(observador);
    }

    public async Task NotificarAsync(string mensaje)
    {
        foreach (var observador in observadores)
        {
            await observador(mensaje);
        }
    }
}
