using Microsoft.EntityFrameworkCore;

namespace Votaciones.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            
        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<Eleccion> Eleccion { get; set; }
        public DbSet<Convocatoria> Convocatoria { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Requisito> Requisito { get; set; }
        public DbSet<Rol_has_permiso> RolHasPermiso { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<ConvocatoriaRequisito> ConvocatoriaRequisitos { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Sufragante> Sufragante { get; set; }
        public DbSet<Ganador> Ganador { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>()
                .HasIndex(u => u.nombre_cargo)
                .IsUnique();
            ;
            
            modelBuilder.Entity<Requisito>()
                .HasIndex(u => u.nombre_requisito)
                .IsUnique();
            ;

            modelBuilder.Entity<Convocatoria>()
                .HasOne(p => p.Cargo)
                .WithMany(b => b.Convocatoria);

            modelBuilder.Entity<Eleccion>()
                .Property(b => b.estado_eleccion)
                .HasDefaultValue("activo");

            //modelBuilder.Entity<Eleccion>()
            //    .Property(b => b.fecha_inicio)
            //    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            //modelBuilder.Entity<Convocatoria>()
            //    .Property(b => b.fecha_inicio_convocatoria)
            //    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Usuario>()
                .Property(b => b.estado_usuario)
                .HasDefaultValue("inactivo");

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.nombre_usuario)
                .IsUnique();
                ;

            modelBuilder.Entity<Candidato>()
            .HasMany(p => p.Eleccion)
            .WithMany(p => p.Candidato)
            .UsingEntity<Ganador>(
                j => j
                    .HasOne(pt => pt.Eleccion)
                    .WithMany(t => t.Ganador)
                    .HasForeignKey(pt => pt.ideleccion),
                j => j
                    .HasOne(pt => pt.Candidato)
                    .WithMany(p => p.Ganador)
                    .HasForeignKey(pt => pt.idcandidato),
                j =>
                {
                    j.HasKey(t => new { t.ideleccion, t.idcandidato });
                });

            modelBuilder.Entity<Convocatoria>()
            .HasMany(p => p.Requisito)
            .WithMany(p => p.Convocatoria)
            .UsingEntity<ConvocatoriaRequisito>(
                j => j
                    .HasOne(pt => pt.Requisito)
                    .WithMany(t => t.ConvocatoriaRequisito)
                    .HasForeignKey(pt => pt.idrequisito),
                j => j
                    .HasOne(pt => pt.Convocatoria)
                    .WithMany(p => p.ConvocatoriaRequisito)
                    .HasForeignKey(pt => pt.idconvocatoria),
                j =>
                {
                    j.HasKey(t => new { t.idrequisito, t.idconvocatoria });
                });

            modelBuilder.Entity<Usuario>()
            .HasMany(p => p.Rol)
            .WithMany(p => p.Usuario)
            .UsingEntity<UsuarioRol>(
                j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(t => t.UsuarioRol)
                    .HasForeignKey(pt => pt.idrol),
                j => j
                    .HasOne(pt => pt.Usuario)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(pt => pt.idusuario),
                j =>
                {
                    j.HasKey(t => new { t.idrol, t.idusuario });
                });

            modelBuilder.Entity<Usuario>()
                .HasOne(p => p.Persona)
                .WithMany(b => b.Usuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(p=> p.Elecciones)
                .WithMany(p=> p.Usuario)
                .UsingEntity<Sufragante>(
                j => j
                      .HasOne(pt => pt.Eleccion)
                      .WithMany(t => t.Sufragante)
                      .HasForeignKey(pt =>pt.ideleccion),
                j => j
                      .HasOne(pt => pt.Usuario)
                      .WithMany(t => t.Sufragante)
                      .HasForeignKey(pt => pt.idusuario),
                j =>
                {
                    //j.Property(pt => pt.fecha_sufragio).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.idusuario, t.ideleccion });
                }
                );

            modelBuilder.Entity<Rol>()
                .HasIndex(u => u.nombre_rol)
                .IsUnique();
            ;

            modelBuilder.Entity<Rol>()
                .Property(b => b.estado_rol)
                .HasDefaultValue("activo");

            modelBuilder.Entity<Rol>()
            .HasMany(p => p.Permiso)
            .WithMany(p => p.Rol)
            .UsingEntity<Rol_has_permiso>(
                j => j
                    .HasOne(pt => pt.Permiso)
                    .WithMany(t => t.Rol_has_permiso)
                    .HasForeignKey(pt => pt.idpermiso),
                j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(p => p.Rol_has_permiso)
                    .HasForeignKey(pt => pt.idrol),
                j =>
                {
                    j.HasKey(t => new { t.idrol, t.idpermiso });
                    j.Property(pt => pt.estado_rol_permiso).HasDefaultValue("activo");
                });

            modelBuilder.Entity<Persona>()
                .HasIndex(u => u.numero_identificacion)
                .IsUnique();
            ;

            
            


        }
    }
}
