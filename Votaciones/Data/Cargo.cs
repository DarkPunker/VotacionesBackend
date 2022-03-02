using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Data
{
    public class Cargo
    {
        [Key]
        public int idcargo { get; set; }
        [MaxLength(45)]
        [Required]
        public string nombre_cargo { get; set; }
        public List<Convocatoria> Convocatoria { get; set; }
    }
}
