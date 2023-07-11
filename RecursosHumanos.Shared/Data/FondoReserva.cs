using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Shared.Data;
public record FondoReserva(int Codigo, string Nombre)
{
    public static string FromCodigo(string codigo) => All.FirstOrDefault(p => p.Codigo.ToLower().Trim() == codigo.ToLower().Trim())?.Codigo ?? "";
    public static string FromNombre(string nombre) => All.FirstOrDefault(p => p.Nombre.ToLower().Trim() == nombre.ToLower().Trim())?.Codigo ?? "";
    public static List<ParametroTrabajador> All => new()
    {
        new("M", "M"),
        new("A", "A"),
        new("N", "N"),
        new("1", "1"),
        new("0", "0")
    };
}
