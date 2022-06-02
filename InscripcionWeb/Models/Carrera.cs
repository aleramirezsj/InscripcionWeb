using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace InscripcionWeb.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Carrera")]
        public string Nombre { get; set; }
        public ObservableCollection <PeriodoAcademico> PeriodosAcademicos { get; set; }
    }
}
