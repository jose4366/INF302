namespace CambiaColores;

public partial class MainPage : ContentPage
{


	public MainPage(UserViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		

	}


}

