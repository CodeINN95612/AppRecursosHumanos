namespace RecursosHumanos.Shared.Models;

public record CentroCostos
{
    public CentroCostos() { }
    public CentroCostos(int codigo, string nombre)
    {
        Codigo = codigo;
        Nombre = nombre;
    }
    public int Codigo { get; set; }
    public string Nombre { get; set; } = "";

    public string CodigoStr => Codigo.ToString();
}
