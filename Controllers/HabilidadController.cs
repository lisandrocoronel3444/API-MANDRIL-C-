using mandrilAPI.Models;
using mandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;
using mandrilAPI.Helpers;

namespace mandrilAPI.Controllers;
[ApiController]
[Route("api/madril/(mandrilId)/[controller]")]
public class HabilidadController : ControllerBase 
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int mandrilID){
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilID);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);

        }
        return Ok(mandril.habilidades);
    }

    [HttpGet("(habilidadID)")]
    public ActionResult<Habilidad> GetHabilidad(int mandrilId, int habilidadID){
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilId);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);

        }
        var habilidad = mandril.habilidades?.FirstOrDefault(h => h.id == habilidadID );
        if(habilidad == null){

        return NotFound(Mensajes.Habilidad.NotFound);
        }
        return Ok(habilidad);

    }

    [HttpPost]
    public ActionResult<Habilidad> PostHabilidad(int mandrilID, HabilidadInsert habilidadInsert){
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilID);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);

        }
        var habilidadExistente = mandril.habilidades.FirstOrDefault(h => h.nombre == habilidadInsert.nombre);
        if(habilidadExistente != null){
            return BadRequest(Mensajes.Habilidad.NombreExistente);
        }
        var maxHabilidad = mandril.habilidades.Any() ? mandril.habilidades.Max(h => h.id) : 0;
        var habilidadNueva = new Habilidad(){
            id = maxHabilidad + 1,
            nombre = habilidadInsert.nombre,
            potencia = habilidadInsert.Potencia
        };
        mandril.habilidades.Add(habilidadNueva);
        return CreatedAtAction(nameof(GetHabilidad),
        new{mandrilId = mandrilID, habilidadId = habilidadNueva.id},
        habilidadNueva
        );


    }
    [HttpPut]
    public ActionResult<Habilidad> PutHabilidad(int mandrilID, int habilidadId, HabilidadInsert habilidadinsert){
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilID);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);

        }

        var habilidadExistente = mandril.habilidades?.FirstOrDefault(h => h.id == habilidadId);

        if(habilidadExistente == null){
            return NotFound(Mensajes.Habilidad.NotFound);
        }
        var habilidadMismoNombre = mandril.habilidades?.FirstOrDefault(h => h.id != habilidadId && h.nombre == habilidadinsert.nombre);

        if(habilidadMismoNombre !=null){
            return BadRequest(Mensajes.Habilidad.NombreExistente);

        }
        habilidadExistente.nombre = habilidadinsert.nombre;
        habilidadExistente.potencia = habilidadinsert.Potencia;
        return NoContent();

    }
    [HttpDelete("habilidadId")]

    public ActionResult<Habilidad> DeleteHabilidad(int mandrilID, int HabilidadId){
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilID);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);

        }
        var habilidadExistente = mandril.habilidades?.FirstOrDefault(h=>h.id == HabilidadId);

        if(habilidadExistente == null){
            return NotFound(Mensajes.Habilidad.NotFound);

        }
        mandril.habilidades?.Remove(habilidadExistente);
        return NoContent();
    }

    

}