namespace Votaciones.Data
{
    public class UsuarioRol
    {
        public int idrol { get; set; }
        public Rol Rol { get; set; }
        public int idusuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
