using mandrilAPI.Models;
namespace mandrilAPI.Services;

public class MandrilDataStore
{
    public List<Mandril> Mandriles { get; set; }

    public static MandrilDataStore Current {get; } = new MandrilDataStore();

    public MandrilDataStore()
    {
        Mandriles = new List<Mandril>(){

        new Mandril(){
            id = 1,
            nombre = "Mini Mandril",
            apellido = "Rodriguez",
            habilidades = new List<Habilidad>(){
                new Habilidad(){
                    id = 1,
                    nombre = "saltar",
                    potencia = Habilidad.Epotencia.Moderado
                }
            }
        },
        new Mandril(){
            id = 2,
            nombre = "Super Mandril",
            apellido = "Fernando",
            habilidades = new List<Habilidad>(){
                new Habilidad(){
                    id = 1,
                    nombre = "saltar",
                    potencia = Habilidad.Epotencia.Moderado
                },
                new Habilidad(){
                    id = 2,
                    nombre = "Caminar",
                    potencia = Habilidad.Epotencia.Intenso
                },
                new Habilidad(){
                    id = 3,
                    nombre = "Gritar",
                    potencia = Habilidad.Epotencia.RePotente
                }
            }

        },
        new Mandril(){
            id = 2,
            nombre = "Mega Mandril",
            apellido = "Licha",
            habilidades = new List<Habilidad>(){
                new Habilidad(){
                    id = 1,
                    nombre = "Nadar",
                    potencia = Habilidad.Epotencia.Intenso
                },
                new Habilidad(){
                    id = 2,
                    nombre = "Correr",
                    potencia = Habilidad.Epotencia.Extremo
                },
                new Habilidad(){
                    id = 3,
                    nombre = "Vomitar",
                    potencia = Habilidad.Epotencia.RePotente
                }
            }

        }

        };
    }
}
