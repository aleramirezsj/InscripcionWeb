using System.ComponentModel.DataAnnotations;

namespace InscripcionWeb.Models
{
    public class PeriodoAcademico
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int CarreraId { get; set; }
        public Carrera? Carrera { get; set; }

    }
}
