using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Boleta;

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
    private int porcentajePropina;

    [ObservableProperty]
    private int cantidadPersonas;

    //hay que calcular total por persona
    public UserViewModel() {
        //inicializa en 0
        totalBoleta = 0;
        total = 0;
        subTotal = 0;
        propina = 0;
        porcentajePropina = 0;
        cantidadPersonas = 1;
    }

    public void ActualizarDatos() {
        if (TotalBoleta >= 0)
        {
            SubTotal = CalcularSubTotal();
            Total = CalcularTotal();
        }
    }

    partial void OnPorcentajePropinaChanged(int value)
    {
        ActualizarDatos();
    }

    partial void OnTotalBoletaChanged(float value)
    {
        ActualizarDatos();
    }



    [RelayCommand]
    private void AsignarPropina(string value)
    {
        // Convierte el parámetro a double y asigna la propina
        if (double.TryParse(value, out double resultado))
        {
            PorcentajePropina = (int)resultado;
        }
    }

    public float CalcularTotal()
    {
        Propina = (float)Math.Ceiling(SubTotal * PorcentajePropina / 100.0);
        return SubTotal + Propina;

    }
    public float CalcularSubTotal()
    {
        return (float)Math.Ceiling(TotalBoleta / (double)CantidadPersonas);
    }

    [RelayCommand]
    public void AumentarCantidadPersonas()
    {
        CantidadPersonas += 1;
        ActualizarDatos();
    }

    [RelayCommand]
    public void DisminuirCantidadPersonas(){
        if (CantidadPersonas >= 2)
        {
            CantidadPersonas -= 1;
            ActualizarDatos();
        }
        
    }
}