using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Data
{
    public class Eleccion
    {
        [Key]
        public int ideleccion { get; set; }

        [MaxLength(255)]
        [Required]
        public string nombre_eleccion { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        public int numero_votos { get; set; }

        public int numero_votos_blanco { get; set; }

        [MaxLength(45)]
        public string estado_eleccion { get; set; }
        public List<Convocatoria> Convocatoria { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
        public List<Sufragante> Sufragante { get; set; }
        public ICollection<Candidato> Candidato { get; set; }

    }
}
