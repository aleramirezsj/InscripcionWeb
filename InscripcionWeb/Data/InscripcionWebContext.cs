using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InscripcionWeb.Models;

namespace InscripcionWeb.Data
{
    public class InscripcionWebContext : DbContext
    {
        public InscripcionWebContext (DbContextOptions<InscripcionWebContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=InscripcionWebContext; User Id = sa; Password = 123; MultipleActiveResultSets = True;");
        }

        public DbSet<InscripcionWeb.Models.Carrera>? Carreras { get; set; }

        public DbSet<InscripcionWeb.Models.PeriodoAcademico>? PeriodosAcademicos { get; set; }
    }
}
