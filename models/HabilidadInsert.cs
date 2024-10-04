using static mandrilAPI.Models.Habilidad;
namespace mandrilAPI.Models;
public class HabilidadInsert
{
    public string nombre { get; set; } = string.Empty;

    public Epotencia Potencia{get; set;}

}