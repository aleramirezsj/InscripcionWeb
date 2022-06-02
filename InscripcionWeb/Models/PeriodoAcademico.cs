using System.ComponentModel.DataAnnotations;

namespace InscripcionWeb.Models
{
    public class PeriodoAcademico
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Período académico")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Carrera")]
        public int CarreraId { get; set; }
        public Carrera? Carrera { get; set; }

    }
}
