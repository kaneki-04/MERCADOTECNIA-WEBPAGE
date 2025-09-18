using System.ComponentModel.DataAnnotations;

namespace EcoSip.Web.Models
{
    public class PersonalizacionBotella
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El tipo de botella es requerido")]
        [Display(Name = "Tipo de Botella")]
        public string? TipoBotella { get; set; }  // Añade ? para permitir NULL
        
        [Display(Name = "Color Principal")]
        public string? Color { get; set; }  // Añade ? para permitir NULL
        
        [Display(Name = "Patrón de Diseño")]
        public string? Patron { get; set; }  // Añade ? para permitir NULL
        
        [Display(Name = "Incluir Nombre")]
        public bool IncluirNombre { get; set; }
        
        [Display(Name = "Nombre Personalizado")]
        public string? NombrePersonalizado { get; set; }  // Añade ? para permitir NULL
        
        [Display(Name = "Incluir Mensaje")]
        public bool IncluirMensaje { get; set; }
        
        [Display(Name = "Mensaje Personalizado")]
        public string? MensajePersonalizado { get; set; }  // Añade ? para permitir NULL
        
        [Display(Name = "Incluir Logo")]
        public bool IncluirLogo { get; set; }
        
        [Display(Name = "Efecto Brillante")]
        public bool EfectoBrillante { get; set; }
        
        [Display(Name = "Tamaño del Diseño")]
        public string? TamañoDiseno { get; set; }  // Añade ? para permitir NULL
        
        [Display(Name = "Precio Base")]
        public decimal PrecioBase { get; set; }
        
        [Display(Name = "Precio Final")]
        public decimal PrecioFinal { get; set; }
        
        public DateTime FechaCreacion { get; set; }
    }
}