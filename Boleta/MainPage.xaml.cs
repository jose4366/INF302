namespace CambiaColores;

public partial class MainPage : ContentPage
{

	private UserViewModel viewModel;
	public MainPage()
	{
		InitializeComponent();
		viewModel = new UserViewModel();
		BindingContext = viewModel;
		

	}


}

