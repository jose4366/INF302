namespace CambiaColores;

using SQLite;

public class Usuario
{
    [PrimaryKey, NotNull]
    public string Rut { get; set; } = string.Empty;

    public string Nombre { get; set; }  = string.Empty;

}