using System.ComponentModel.DataAnnotations;

namespace InscripcionWeb.Models
{
    public class Materia
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Materia")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Período académico")]
        public int PeriodoAcademicoId { get; set; }
        public PeriodoAcademico? PeriodoAcademico { get; set; }
    }
}
