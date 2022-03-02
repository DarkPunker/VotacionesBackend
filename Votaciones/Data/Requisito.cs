using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Data
{
    public class Requisito
    {
        [Key]
        public int idrequisito { get; set; }
        [MaxLength(45)]
        [Required]
        public string nombre_requisito { get; set; }
        public ICollection<Convocatoria> Convocatoria { get; set; }

    }
}
