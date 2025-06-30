namespace CambiaColores;

public interface IDataBaseService
{
    public int NuevaTransaccion(Transacciones entidad);

    public List<Transacciones> ObtenerTransacciones(string rut);

    public Usuario ObtenerUsuario(string rut);


}