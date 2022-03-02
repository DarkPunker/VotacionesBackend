using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Data
{
    public class Sufragante
    {
        [Required]
        public DateTime fecha_sufragio { get; set; }
        public Candidato Candidato { get; set; }
        public int idusuario { get; set; }
        public Usuario Usuario { get; set; }
        public int ideleccion { get; set; }
        public Eleccion Eleccion { get; set; }

    }
}
