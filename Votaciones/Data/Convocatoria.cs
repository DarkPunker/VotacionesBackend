using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Votaciones.Data
{
    public class Convocatoria
    {
        [Key]
        public int idconvocatoria { get; set; }
        [MaxLength(255)]
        [Required]
        public string nombre_convocatoria { get; set; }
        public DateTime fecha_inicio_convocatoria { get; set; }
        public DateTime fecha_fin_convocatoria { get; set; }

        public int idcargo { get; set; }
        [ForeignKey("idcargo")]
        public Cargo Cargo { get; set; }
        public int ideleccion { get; set; }
        [ForeignKey("ideleccion")]
        public Eleccion Eleccion { get; set; }
        public List<Candidato> Candidato { get; set; }
        public ICollection<Requisito> Requisito { get; set; }
        public List<ConvocatoriaRequisito> ConvocatoriaRequisito { get; set; }
    }
}
