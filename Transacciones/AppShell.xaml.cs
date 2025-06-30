namespace CambiaColores;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registrar rutas para navegación
        Routing.RegisterRoute(nameof(TransaccionesPage), typeof(TransaccionesPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}
