using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CambiaColores;

public partial class UserViewModel : ObservableObject {


    [ObservableProperty]
    private float totalBoleta;

    [ObservableProperty]
    private float total;
    [ObservableProperty]
    private float subTotal;
    [ObservableProperty]
    private float propina;
    [ObservableProperty]
    private int porcernajePropina;

    [ObservableProperty]
    private int cantidadPersonas;

    //hay que calcular total por persona
    public UserViewModel() {
        //inicializa en 0
        totalBoleta = 0;
        total = 0;
        subTotal = 0;
        propina = 0;
        porcernajePropina = 0;
        cantidadPersonas = 1;
    }

    [RelayCommand]
    public void ActualizarDatos() {
        if (TotalBoleta >= 0)
        {
            SubTotal = CalcularSubTotal();
            Total = CalcularTotal();
        }
    }

    [RelayCommand]
    private void AsignarPropina(string value)
    {
        // Convierte el parámetro a double y asigna la propina
        if (double.TryParse(value, out double resultado))
        {
            PorcernajePropina = (int)resultado;
        }
    }

    public float CalcularTotal()
    {
        Propina = SubTotal * PorcernajePropina / 100;
        return SubTotal + Propina;

    }
    public float CalcularSubTotal()
    {
        return TotalBoleta / CantidadPersonas;
    }

    [RelayCommand]
    public void AumentarCantidadPersonas(){
        CantidadPersonas +=1;
    }

    [RelayCommand]
    public void DisminuirCantidadPersonas(){
        if(CantidadPersonas >= 2){
            CantidadPersonas -=1;
        }
        
    }
}