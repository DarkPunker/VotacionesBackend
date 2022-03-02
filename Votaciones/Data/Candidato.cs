using System.Collections.Generic;

namespace Votaciones.Data
{
    public class Candidato
    {
        public int numero_participante { get; set; }
        public int idpersona { get; set; }
        public Persona Persona { get; set; }
        public int idconvocatoria { get; set; }
        public Convocatoria Convocatoria { get; set; }

        public List<Sufragante> Sufragante { get; set; }
        public ICollection<Eleccion> Eleccion { get; set; }
    }
}
