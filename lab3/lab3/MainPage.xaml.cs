namespace lab3;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        MessageText.Text = "¡Botón presionado!";
    }

}
