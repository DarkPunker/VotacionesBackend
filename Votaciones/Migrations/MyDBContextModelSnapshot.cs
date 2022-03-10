﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Votaciones.Data;

namespace Votaciones.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Votaciones.Data.Candidato", b =>
                {
                    b.Property<int>("idcandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("estado_participante")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("idconvocatoria")
                        .HasColumnType("int");

                    b.Property<int>("idpersona")
                        .HasColumnType("int");

                    b.Property<int>("numero_participante")
                        .HasColumnType("int");

                    b.HasKey("idcandidato");

                    b.HasIndex("idconvocatoria");

                    b.HasIndex("idpersona");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("Votaciones.Data.Cargo", b =>
                {
                    b.Property<int>("idcargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre_cargo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.HasKey("idcargo");

                    b.HasIndex("nombre_cargo")
                        .IsUnique();

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("Votaciones.Data.Convocatoria", b =>
                {
                    b.Property<int>("idconvocatoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_fin_convocatoria")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fecha_inicio_convocatoria")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("idcargo")
                        .HasColumnType("int");

                    b.Property<int>("ideleccion")
                        .HasColumnType("int");

                    b.Property<string>("nombre_convocatoria")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("idconvocatoria");

                    b.HasIndex("idcargo");

                    b.HasIndex("ideleccion");

                    b.ToTable("Convocatoria");
                });

            modelBuilder.Entity("Votaciones.Data.ConvocatoriaRequisito", b =>
                {
                    b.Property<int>("idrequisito")
                        .HasColumnType("int");

                    b.Property<int>("idconvocatoria")
                        .HasColumnType("int");

                    b.HasKey("idrequisito", "idconvocatoria");

                    b.HasIndex("idconvocatoria");

                    b.ToTable("ConvocatoriaRequisitos");
                });

            modelBuilder.Entity("Votaciones.Data.Eleccion", b =>
                {
                    b.Property<int>("ideleccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("estado_eleccion")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasDefaultValue("activo");

                    b.Property<DateTime>("fecha_fin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fecha_inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("nombre_eleccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("numero_votos")
                        .HasColumnType("int");

                    b.Property<int>("numero_votos_blanco")
                        .HasColumnType("int");

                    b.HasKey("ideleccion");

                    b.ToTable("Eleccion");
                });

            modelBuilder.Entity("Votaciones.Data.Ganador", b =>
                {
                    b.Property<int>("ideleccion")
                        .HasColumnType("int");

                    b.Property<int>("idcandidato")
                        .HasColumnType("int");

                    b.HasKey("ideleccion", "idcandidato");

                    b.HasIndex("idcandidato");

                    b.ToTable("Ganador");
                });

            modelBuilder.Entity("Votaciones.Data.Permiso", b =>
                {
                    b.Property<int>("idpermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("accion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("descripcion_permiso")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("modulo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.HasKey("idpermiso");

                    b.ToTable("Permiso");
                });

            modelBuilder.Entity("Votaciones.Data.Persona", b =>
                {
                    b.Property<int>("idpersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("numero_identificacion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("primer_apellido")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("primer_nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("segundo_apellido")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("segundo_nombre")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("telefono")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.HasKey("idpersona");

                    b.HasIndex("numero_identificacion")
                        .IsUnique();

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Votaciones.Data.Requisito", b =>
                {
                    b.Property<int>("idrequisito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre_requisito")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.HasKey("idrequisito");

                    b.HasIndex("nombre_requisito")
                        .IsUnique();

                    b.ToTable("Requisito");
                });

            modelBuilder.Entity("Votaciones.Data.Rol", b =>
                {
                    b.Property<int>("idrol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descripcion_rol")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("estado_rol")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasDefaultValue("activo");

                    b.Property<string>("nombre_rol")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.HasKey("idrol");

                    b.HasIndex("nombre_rol")
                        .IsUnique();

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Votaciones.Data.Rol_has_permiso", b =>
                {
                    b.Property<int>("idrol")
                        .HasColumnType("int");

                    b.Property<int>("idpermiso")
                        .HasColumnType("int");

                    b.Property<string>("estado_rol_permiso")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasDefaultValue("activo");

                    b.HasKey("idrol", "idpermiso");

                    b.HasIndex("idpermiso");

                    b.ToTable("RolHasPermiso");
                });

            modelBuilder.Entity("Votaciones.Data.Sufragante", b =>
                {
                    b.Property<int>("idusuario")
                        .HasColumnType("int");

                    b.Property<int>("ideleccion")
                        .HasColumnType("int");

                    b.Property<int?>("Candidatoidcandidato")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_sufragio")
                        .HasColumnType("datetime(6)");

                    b.HasKey("idusuario", "ideleccion");

                    b.HasIndex("Candidatoidcandidato");

                    b.HasIndex("ideleccion");

                    b.ToTable("Sufragante");
                });

            modelBuilder.Entity("Votaciones.Data.Usuario", b =>
                {
                    b.Property<int>("idusuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.Property<string>("estado_usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasDefaultValue("inactivo");

                    b.Property<int>("idpersona")
                        .HasColumnType("int");

                    b.Property<string>("nombre_usuario")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4");

                    b.HasKey("idusuario");

                    b.HasIndex("idpersona");

                    b.HasIndex("nombre_usuario")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Votaciones.Data.UsuarioRol", b =>
                {
                    b.Property<int>("idrol")
                        .HasColumnType("int");

                    b.Property<int>("idusuario")
                        .HasColumnType("int");

                    b.HasKey("idrol", "idusuario");

                    b.HasIndex("idusuario");

                    b.ToTable("UsuarioRol");
                });

            modelBuilder.Entity("Votaciones.Data.Candidato", b =>
                {
                    b.HasOne("Votaciones.Data.Convocatoria", "Convocatoria")
                        .WithMany("Candidato")
                        .HasForeignKey("idconvocatoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Votaciones.Data.Persona", "Persona")
                        .WithMany("Candidato")
                        .HasForeignKey("idpersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Convocatoria");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Votaciones.Data.Convocatoria", b =>
                {
                    b.HasOne("Votaciones.Data.Cargo", "Cargo")
                        .WithMany("Convocatoria")
                        .HasForeignKey("idcargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Votaciones.Data.Eleccion", "Eleccion")
                        .WithMany("Convocatoria")
                        .HasForeignKey("ideleccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Eleccion");
                });

            modelBuilder.Entity("Votaciones.Data.ConvocatoriaRequisito", b =>
                {
                    b.HasOne("Votaciones.Data.Convocatoria", "Convocatoria")
                        .WithMany("ConvocatoriaRequisito")
                        .HasForeignKey("idconvocatoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Votaciones.Data.Requisito", "Requisito")
                        .WithMany("ConvocatoriaRequisito")
                        .HasForeignKey("idrequisito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Convocatoria");

                    b.Navigation("Requisito");
                });

            modelBuilder.Entity("Votaciones.Data.Ganador", b =>
                {
                    b.HasOne("Votaciones.Data.Candidato", "Candidato")
                        .WithMany("Ganador")
                        .HasForeignKey("idcandidato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Votaciones.Data.Eleccion", "Eleccion")
                        .WithMany("Ganador")
                        .HasForeignKey("ideleccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Eleccion");
                });

            modelBuilder.Entity("Votaciones.Data.Rol_has_permiso", b =>
                {
                    b.HasOne("Votaciones.Data.Permiso", "Permiso")
                        .WithMany("Rol_has_permiso")
                        .HasForeignKey("idpermiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Votaciones.Data.Rol", "Rol")
                        .WithMany("Rol_has_permiso")
                        .HasForeignKey("idrol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Votaciones.Data.Sufragante", b =>
                {
                    b.HasOne("Votaciones.Data.Candidato", "Candidato")
                        .WithMany("Sufragante")
                        .HasForeignKey("Candidatoidcandidato");

                    b.HasOne("Votaciones.Data.Eleccion", "Eleccion")
                        .WithMany("Sufragante")
                        .HasForeignKey("ideleccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Votaciones.Data.Usuario", "Usuario")
                        .WithMany("Sufragante")
                        .HasForeignKey("idusuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Eleccion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Votaciones.Data.Usuario", b =>
                {
                    b.HasOne("Votaciones.Data.Persona", "Persona")
                        .WithMany("Usuario")
                        .HasForeignKey("idpersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Votaciones.Data.UsuarioRol", b =>
                {
                    b.HasOne("Votaciones.Data.Rol", "Rol")
                        .WithMany("UsuarioRol")
                        .HasForeignKey("idrol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Votaciones.Data.Usuario", "Usuario")
                        .WithMany("UsuarioRol")
                        .HasForeignKey("idusuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Votaciones.Data.Candidato", b =>
                {
                    b.Navigation("Ganador");

                    b.Navigation("Sufragante");
                });

            modelBuilder.Entity("Votaciones.Data.Cargo", b =>
                {
                    b.Navigation("Convocatoria");
                });

            modelBuilder.Entity("Votaciones.Data.Convocatoria", b =>
                {
                    b.Navigation("Candidato");

                    b.Navigation("ConvocatoriaRequisito");
                });

            modelBuilder.Entity("Votaciones.Data.Eleccion", b =>
                {
                    b.Navigation("Convocatoria");

                    b.Navigation("Ganador");

                    b.Navigation("Sufragante");
                });

            modelBuilder.Entity("Votaciones.Data.Permiso", b =>
                {
                    b.Navigation("Rol_has_permiso");
                });

            modelBuilder.Entity("Votaciones.Data.Persona", b =>
                {
                    b.Navigation("Candidato");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Votaciones.Data.Requisito", b =>
                {
                    b.Navigation("ConvocatoriaRequisito");
                });

            modelBuilder.Entity("Votaciones.Data.Rol", b =>
                {
                    b.Navigation("Rol_has_permiso");

                    b.Navigation("UsuarioRol");
                });

            modelBuilder.Entity("Votaciones.Data.Usuario", b =>
                {
                    b.Navigation("Sufragante");

                    b.Navigation("UsuarioRol");
                });
#pragma warning restore 612, 618
        }
    }
}
