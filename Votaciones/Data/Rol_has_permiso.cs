using System.ComponentModel.DataAnnotations;

namespace Votaciones.Data
{
    public class Rol_has_permiso
    {
        public int idrol { get; set; }
        public Rol Rol { get; set; }
        public int idpermiso { get; set; }
        public Permiso Permiso { get; set; }
        [MaxLength(45)]
        public string estado_rol_permiso { get; set; }
    }
}
