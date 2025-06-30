namespace CambiaColores;

public partial class TransaccionesPage : ContentPage
{
    public TransaccionesPage(UserViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}