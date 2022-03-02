using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Data
{
    public class Permiso
    {
        [Key]
        public int idpermiso { get; set; }
        [MaxLength(45)]
        [Required]
        public string accion { get; set; }
        [MaxLength(45)]
        [Required]
        public string modulo { get; set; }
        [MaxLength(45)]
        public string descripcion_permiso { get; set; }
        public ICollection<Rol> Rol { get; set; }
        public List<Rol_has_permiso> Rol_has_permiso { get; set; }
    }
}
