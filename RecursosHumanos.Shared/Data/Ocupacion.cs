using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Shared.Data;

public record Ocupacion(int Codigo, string Nombre)
{
    public static string FromNombre(string nombre) => All.FirstOrDefault(p => p.Nombre.ToLower().Trim() == nombre.ToLower().Trim())?.Codigo ?? "";
    public static string FromCodigo(string codigo) => All.FirstOrDefault(p => p.Codigo.ToLower().Trim() == codigo.ToLower().Trim())?.Codigo ?? "";
    public static List<ParametroTrabajador> All => new()
    {
        new("1", "Administrativo"),
        new("2", "Operaciones")
    };
}
