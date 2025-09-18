using Microsoft.AspNetCore.Mvc;
using EcoSip.Web.Models;
using System.Diagnostics;

namespace EcoSip.Web.Controllers
{
    public class PersonalizacionController : Controller
    {
        private readonly ILogger<PersonalizacionController> _logger;

        public PersonalizacionController(ILogger<PersonalizacionController> logger)
        {
            _logger = logger;
        }

        // GET: Personalizacion/Index
        public IActionResult Index()
        {
            var model = new PersonalizacionBotella
            {
                TipoBotella = "pet-500ml",
                Color = "#2E8B57",
                Patron = "none",
                TamañoDiseno = "Normal",
                PrecioBase = 5.00m,
                PrecioFinal = 5.00m,
                FechaCreacion = DateTime.Now
            };
            
            return View(model);
        }

        // POST: Personalizacion/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PersonalizacionBotella model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Calcular el precio final basado en las selecciones
                    model.PrecioFinal = CalcularPrecioFinal(model);
                    
                    // Guardar la personalización en la base de datos (implementar según tu ORM)
                    // _context.Personalizaciones.Add(model);
                    // _context.SaveChanges();
                    
                    // Redirigir a la página de confirmación
                    return RedirectToAction("Confirmacion", new { id = model.Id });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al procesar la personalización");
                    ModelState.AddModelError("", "Ocurrió un error al procesar su personalización. Por favor, intente nuevamente.");
                }
            }
            
            // Si hay errores, volver a mostrar el formulario
            return View(model);
        }

        // GET: Personalizacion/Confirmacion
        public IActionResult Confirmacion(int id)
        {
            // Obtener la personalización de la base de datos (implementar según tu ORM)
            // var personalizacion = _context.Personalizaciones.FirstOrDefault(p => p.Id == id);
            
            // Para este ejemplo, creamos un objeto de prueba
            var personalizacion = new PersonalizacionBotella
            {
                Id = id,
                TipoBotella = "pet-500ml",
                Color = "#2E8B57",
                Patron = "none",
                TamañoDiseno = "Normal",
                PrecioBase = 5.00m,
                PrecioFinal = 8.50m,
                FechaCreacion = DateTime.Now
            };
            
            if (personalizacion == null)
            {
                return NotFound();
            }
            
            return View(personalizacion);
        }

        // Método para calcular el precio final
        private decimal CalcularPrecioFinal(PersonalizacionBotella model)
        {
            decimal precio = model.PrecioBase;
            
            // Añadir coste según el patrón
            if (model.Patron != "none")
            {
                precio += 1.50m;
            }
            
            // Añadir coste por personalizaciones adicionales
            if (model.IncluirNombre)
            {
                precio += 2.50m;
            }
            
            if (model.IncluirMensaje)
            {
                precio += 3.00m;
            }
            
            if (model.IncluirLogo)
            {
                precio += 5.00m;
            }
            
            if (model.EfectoBrillante)
            {
                precio += 1.50m;
            }
            
            // Ajustar por tamaño
            if (model.TamañoDiseno == "Grande")
            {
                precio += 1.50m;
            }
            else if (model.TamañoDiseno == "Pequeño")
            {
                precio -= 0.50m;
            }
            
            return precio;
        }

        // API para calcular precio en tiempo real (para AJAX)
        [HttpPost]
        public JsonResult CalcularPrecio([FromBody] PersonalizacionBotella model)
        {
            if (model == null)
            {
                return Json(new { error = "Datos inválidos" });
            }
            
            decimal precioFinal = CalcularPrecioFinal(model);
            
            return Json(new { 
                precioBase = model.PrecioBase,
                precioFinal = precioFinal,
                ahorro = precioFinal + 2.00m // Ejemplo de ahorro calculado
            });
        }
    }
}