namespace CambiaColores;

using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

public class Transacciones
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; }

    [ForeignKey(nameof(Usuario))]
    public string Rut { get; set; } = string.Empty;

    public string Glosa { get; set; } = string.Empty;

    public float Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    [Ignore]
    public Color CantidadColor => Cantidad >= 0 ? Colors.Green : Colors.Red;

}