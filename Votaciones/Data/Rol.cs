using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Data
{
    public class Rol
    {
        [Key]
        public int idrol { get; set; }
        [MaxLength(45)]
        [Required]
        public string nombre_rol { get; set; }
        [MaxLength(45)]
        [Required]
        public string descripcion_rol { get; set; }
        [MaxLength(45)]
        public string estado_rol { get; set; }
        public ICollection<Permiso> Permiso { get; set; }
        public List<Rol_has_permiso> Rol_has_permiso { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
