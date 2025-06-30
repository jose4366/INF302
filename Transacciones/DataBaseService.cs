using SQLite;

namespace CambiaColores;

public class DataBaseService : IDataBaseService
{
    private SQLiteConnection _connection;

    public DataBaseService(String dbName = "TransaccionDBP.db")
    {
        var dbPath = DataBasePathHelper.GetDataBasePath(dbName);
        _connection = new SQLiteConnection(dbPath);
        _connection.CreateTable<Transacciones>();
        _connection.CreateTable<Usuario>();
    }

    public int NuevaTransaccion(Transacciones entidad)
    {
        return _connection.Insert(entidad);
    }

    public List<Transacciones> ObtenerTransacciones(string rut)
    {
        var lista = _connection.Table<Transacciones>()
                    .Where(p => p.Rut == rut)
                    .OrderByDescending(p => p.Fecha)
                    .ToList();
        return lista;
    }

    public Usuario ObtenerUsuario(string rut)
    {
        //var aux = new Usuario {Rut = rut,Nombre = "Jaime"};
        //_connection.Insert(aux);
        var usuario = _connection.Table<Usuario>()
                    .Where(p => p.Rut == rut)
                    .FirstOrDefault();
        return usuario;
    }
}

