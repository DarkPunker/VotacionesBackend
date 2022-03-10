using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Votaciones.Data
{
    public class Candidato
    {
        [Key]
        public int idcandidato { get; set; }
        public string estado_participante { get; set; }
        public int numero_participante { get; set; }
        public int idpersona { get; set; }
        [ForeignKey("idpersona")]
        public Persona Persona { get; set; }
        public int idconvocatoria { get; set; }
        [ForeignKey("idconvocatoria")]
        public Convocatoria Convocatoria { get; set; }

        public List<Sufragante> Sufragante { get; set; }
        public ICollection<Eleccion> Eleccion { get; set; }
        public List<Ganador> Ganador { get; set; }
    }
}
