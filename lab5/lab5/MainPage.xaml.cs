using System;

namespace lab5;

public sealed partial class MainPage : Page
{
    private List<Usuario> usuarios = new List<Usuario>();
    private Stack<string> errores = new Stack<string>();
    private Notificador notificador = new Notificador();

    public MainPage()
    {
        this.InitializeComponent();
        notificador.Suscribir(async mensaje => await Notificar(mensaje));
    }

    private async Task Notificar(string mensaje)
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
        {
            var dialog = new ContentDialog
            {
                Title = "Notificación",
                Content = mensaje,
                CloseButtonText = "Aceptar"
            };

            if (this.Content is FrameworkElement frameworkElement)
            {
                dialog.XamlRoot = frameworkElement.XamlRoot; // Ensure XamlRoot is set
            }
            await dialog.ShowAsync();
        });
    }


    private async void AgregarUsuario_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var usuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Correo = txtCorreo.Text
            };

            usuarios.Add(usuario);
            ActualizarListView();
            notificador.NotificarAsync($"Usuario {usuario.Nombre} agregado.");
        }
        catch (Exception ex)
        {
            errores.Push($"{DateTime.Now}: {ex.Message}");
            await Notificar($"Error al agregar usuario: {ex.Message}");
        }
    }

    private async void BuscarUsuario_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Validar que el campo de búsqueda no esté vacío
            if (string.IsNullOrWhiteSpace(txtBuscarCorreo.Text))
            {
                await notificador.NotificarAsync("Por favor, ingrese un correo electrónico para buscar.");
                return;
            }
            var correo = txtBuscarCorreo.Text.Trim();

            // Realizar la búsqueda utilizando LINQ
            var resultado = usuarios
                .Where(u => u.Correo.Contains(correo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Actualizar el ListView con los resultados
            lstUsuarios.ItemsSource = resultado;

            if (resultado.Any())
            {
                await notificador.NotificarAsync($"Se encontraron {resultado.Count} usuarios con el correo: {correo}");
            }
            else
            {
                await notificador.NotificarAsync($"No se encontraron usuarios con el correo: {correo}");
            }
        }
        catch (Exception ex)
        {
            errores.Push($"{DateTime.Now}: {ex.Message}");
            await notificador.NotificarAsync($"Error al buscar usuario: {ex.Message}");
        }
    }

    private void OrdenarAscendente_Click(object sender, RoutedEventArgs e)
    {
        usuarios = usuarios.OrderBy(u => u.Nombre).ToList();
        ActualizarListView();
        Task task = notificador.NotificarAsync("Usuarios ordenados ascendente.");
    }

    private void OrdenarDescendente_Click(object sender, RoutedEventArgs e)
    {
        usuarios = usuarios.OrderByDescending(u => u.Nombre).ToList();
        ActualizarListView();
        Task task = notificador.NotificarAsync("Usuarios ordenados descendente.");
    }

    private void MostrarErrores_Click(object sender, RoutedEventArgs e)
    {
        var mensajes = string.Join(Environment.NewLine, errores);
        Task task = notificador.NotificarAsync($"Errores:{Environment.NewLine}{mensajes}");
    }

    private void ActualizarListView()
    {
        lstUsuarios.ItemsSource = null;
        lstUsuarios.ItemsSource = usuarios;
        txtResumen.Text = $"Total de usuarios: {usuarios.Count}";
    }

}
