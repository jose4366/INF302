using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;

namespace CambiaColores;

public partial class UserViewModel : ObservableObject
{

    // carga el user de la BD
    [ObservableProperty]
    private string nombre;


    private string rut;

    [ObservableProperty]
    private float balance;


    [ObservableProperty]
    private float egresos;


    [ObservableProperty]
    private float ingresos;


    //Transacciones, para poder usar los relay commands
    [ObservableProperty]
    private string glosa = "";

    [ObservableProperty]
    private float cantidad;

    [ObservableProperty]
    private DateTime fecha;

    public DateTime MinDate => DateTime.Today;
    public DateTime MaxDate => DateTime.Today.AddDays(30);

    [ObservableProperty]
    private bool ingreso;
    private readonly DataBaseService _db = new();

    [ObservableProperty]
    private ObservableCollection<Transacciones> transacciones = new();

    //hay que calcular total por persona
    public UserViewModel()
    {
        //inicializa en 0
        rut = "1010-1";
        var u = _db.ObtenerUsuario(rut);

        Nombre = u.Nombre;
        DespejarVariables();
        CargarTransacciones();

        Balance = CalcularBalance();
        Egresos = CalcularGastos();
        Ingresos = CalcularIngresos();
        //falta crear una pura instancia de un usuario y debería funcionar
    }

    public void CargarTransacciones()
    {
        Transacciones.Clear();
        var lista = _db.ObtenerTransacciones(rut);
        foreach (var u in lista) Transacciones.Add(u);

    }

    [RelayCommand]
    public void AgregarTransacciones()
    {
        var c = Cantidad;
        if (!Ingreso)
        {
            c = -c;
        }
        _db.NuevaTransaccion(new Transacciones { Rut = rut, Glosa = Glosa, Cantidad = c, Fecha = Fecha });
        DespejarVariables();
        CargarTransacciones();
        Balance = CalcularBalance();
        Egresos = CalcularGastos();
        Ingresos = CalcularIngresos();
        _ = IrAMainPage();
    }

    [RelayCommand]
    private async Task IrASegundaPagina()
    {
        await Shell.Current.GoToAsync(nameof(TransaccionesPage));
    }

    [RelayCommand]
    private async Task IrAMainPage()
    {
        DespejarVariables();
        await Shell.Current.GoToAsync(nameof(MainPage));
    }

    [RelayCommand]
    void AlternarIngreso() => Ingreso = !Ingreso;
    public void DespejarVariables()
    {
        Glosa = "";
        Cantidad = 0;
        Fecha = new DateTime();
        Ingreso = false;
    }

    public float CalcularBalance()
    {
        float aux = 0;
        foreach (var t in Transacciones)
        {
            aux += t.Cantidad;
        }
        return aux;

    }

    public float CalcularIngresos()
    {
        float aux = 0;
        foreach (var t in Transacciones)
        {
            if (t.Cantidad >= 0)
            {
                aux += t.Cantidad;
            }

        }
        return aux;
    }
    public float CalcularGastos()
    {
        float aux = 0;
        foreach (var t in Transacciones)
        {
            if (t.Cantidad <= 0)
            {
                aux += t.Cantidad;
            }
        }
        return Math.Abs(aux);
    }
    
    
}