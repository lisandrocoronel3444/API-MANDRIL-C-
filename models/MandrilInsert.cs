using System.ComponentModel.DataAnnotations;

namespace mandrilAPI.Models;

public class MandrilInsert{
    [Required]
    [MaxLength(40)]

    public string nombre { get; set; } = string.Empty;
    [Required]
    [MaxLength(40)]

    public string apellido { get; set; } = string.Empty;
}