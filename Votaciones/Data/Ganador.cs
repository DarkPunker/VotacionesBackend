namespace Votaciones.Data
{
    public class Ganador
    {
        public int ideleccion { get; set; }
        public Eleccion Eleccion { get; set; }
        public int idcandidato { get; set; }
        public Candidato Candidato { get; set; }
    }
}
