using System.ComponentModel.DataAnnotations;

namespace InscripcionWeb.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Carrera")]
        public string Nombre { get; set; }
    }
}
