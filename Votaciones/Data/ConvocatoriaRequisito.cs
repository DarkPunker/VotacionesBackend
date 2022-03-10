namespace Votaciones.Data
{
    public class ConvocatoriaRequisito
    {
        public int idconvocatoria { get; set; }
        public Convocatoria Convocatoria { get; set; }
        public int idrequisito { get; set; }
        public Requisito Requisito { get; set; }

    }
}
