using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Shared.Data;

public record CategoriaOcupacion
{
    public static string FromCodigo(string codigo) => All.FirstOrDefault(p => p.Codigo.ToLower().Trim() == codigo.ToLower().Trim())?.Codigo ?? "";
    public static List<ParametroTrabajador> All => new()
    {
        new("7", "Profesores"),
        new("2", "Personal de Secretaria"),
        new("3", "Autoridades y Directivos"),
        new("4", "Personal de Servicio"),
        new("5", "Personal de Consejeria"),
        new("6", "Personal de Apoyo o Auxiliar"),
        new("1", "Trabajador"),
        new("8", "Personal de Contabilidad"),
        new("9", "Personal de Mantenimiento"),
        new("10", "Personal Religioso"),
        new("11", "Empleador"),
        new("12", "Servicio Profesionales")
    };
}
