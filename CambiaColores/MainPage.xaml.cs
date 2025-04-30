using System.Collections;

namespace CambiaColores;

public partial class MainPage : ContentPage
{
	int red = 0;
	int green = 0;
	int blue = 0;

	public MainPage()
	{
		InitializeComponent();

	}


	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e){
        
		Slider slider = (Slider)sender;
		double valor = Math.Round(e.NewValue);
		if(slider == redSlider){
			red = (int)valor; 
		}
		else if(slider == greenSlider){
			green = (int)valor; 
		}
		else if(slider == blueSlider){
			blue = (int)valor; 
		}
		rgbValueLabel.Text = $"RGB: ({red},{green},{blue})";
		preColor.BackgroundColor = Color.FromRgb(red,green,blue);
		string hexColor = ColorPropiedades.ColorToHex(red,green,blue);
		hexValueLabel.Text = $"#{hexColor}";
		


		
    }
	void RandomButton_Clicked(object sender, EventArgs e){
		(red,green,blue) = ColorPropiedades.RandomColor();
		redSlider.Value = red;
		greenSlider.Value = green;
		blueSlider.Value = blue;
		rgbValueLabel.Text = $"RGB: ({red},{green},{blue})";
		OnChangeBackground(this,null);
		
    }
	public void OnChangeBackground(object sender, EventArgs? e){
        
		Pagina.BackgroundColor = Color.FromRgb(red, green, blue);
    }

	public void Clipboard_Clicked(object sender, EventArgs e){
		string hexColor = ColorPropiedades.ColorToHex(red,green,blue);
		Clipboard.SetTextAsync(hexColor);
	}


}

