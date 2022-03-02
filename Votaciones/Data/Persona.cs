using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Data
{
    public class Persona
    {
        
        [Key]
        public int idpersona { get; set; }
        [MaxLength(45)]
        [Required]
        public string numero_identificacion { get; set; }
        [MaxLength(45)]
        [Required]
        public string primer_nombre { get; set; }
        [MaxLength(45)]
        public string segundo_nombre { get; set; }
        [MaxLength(45)]
        [Required]
        public string primer_apellido { get; set; }
        [MaxLength(45)]
        public string segundo_apellido { get; set; }
        [MaxLength(45)]
        public string telefono { get; set; }
        [MaxLength(45)]
        public string direccion { get; set; }

        public List<Usuario> Usuario { get; set; }
        public ICollection<Convocatoria> Convocatoria { get; set; }
        public List<Candidato> Candidato { get; set; }
    }
}
