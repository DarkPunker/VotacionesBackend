using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Votaciones.Data
{
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }
        [MaxLength(45)]
        [Required]
        public string nombre_usuario { get; set; }
        [MaxLength(45)]
        [Required]
        public string contrasena { get; set; }
        [MaxLength(45)]
        public string estado_usuario { get; set; }

        public int idpersona { get; set; }
        [ForeignKey("idpersona")]
        public Persona Persona { get; set; }

        public ICollection<Rol> Rol { get; set; }

        public ICollection<Eleccion> Elecciones { get; set; }
        public List<Sufragante> Sufragante { get; set; }
    }
}
