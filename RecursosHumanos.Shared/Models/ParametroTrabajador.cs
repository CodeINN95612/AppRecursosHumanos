namespace RecursosHumanos.Shared.Models;

public record ParametroTrabajador
{
    public ParametroTrabajador(string codigo, string nombre)
    {
        Codigo = codigo;
        Nombre = nombre;
    }

    public ParametroTrabajador()
    {
        
    }

    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
}