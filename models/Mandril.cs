

namespace mandrilAPI.Models;

public class Mandril{
    public int id { get; set; }

    public string nombre { get; set; } = string.Empty;

    public string apellido { get; set; } = string.Empty;

    public List<Habilidad>? habilidades {get; set;} = new List<Habilidad>();

}