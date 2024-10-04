using mandrilAPI.Models;
using mandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;
using mandrilAPI.Helpers;
namespace mandrilAPI.controllers;

[ApiController]
[Route("[controller]")]
public class MandrilController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandriles()
    {
        return Ok(MandrilDataStore.Current.Mandriles);

    }
    [HttpGet("(mandrilID)")]
    public ActionResult<Mandril> GetMandril(int mandrilID)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilID);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);

        }
        return Ok(mandril);

    }
    [HttpPost]
    public ActionResult<Mandril> PostMandril(MandrilInsert mandrilinsert)
    {
        var maxMandrilID = MandrilDataStore.Current.Mandriles.Max(x => x.id);
        var mandrilNuevo = new Mandril()
        {
            id = maxMandrilID + 1,
            nombre = mandrilinsert.nombre,
            apellido = mandrilinsert.apellido
        };
        MandrilDataStore.Current.Mandriles.Add(mandrilNuevo);

        return CreatedAtAction(nameof(GetMandril),
        new { maxMandrilID = mandrilNuevo.id },
        mandrilNuevo);

    }
    [HttpPut("(mandrilID)")]

    public ActionResult<Mandril> PutMandril(int mandrilID, [FromBody] MandrilInsert mandrilInsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilID);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);

        }
        mandril.nombre = mandrilInsert.nombre;
        mandril.apellido = mandrilInsert.apellido;
        return NoContent();

    }
    [HttpDelete("(mandrilID)")]
    public ActionResult<Mandril> DeleteMandril(int mandrilID)
    {

        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilID);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);

        }
        MandrilDataStore.Current.Mandriles.Remove(mandril);
        return NoContent();
    }



}