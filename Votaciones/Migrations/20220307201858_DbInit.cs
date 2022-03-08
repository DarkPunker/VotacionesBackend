using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Votaciones.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    idcargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_cargo = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.idcargo);
                });

            migrationBuilder.CreateTable(
                name: "Eleccion",
                columns: table => new
                {
                    ideleccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_eleccion = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", maxLength: 255, nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    numero_votos = table.Column<int>(type: "int", nullable: false),
                    numero_votos_blanco = table.Column<int>(type: "int", nullable: false),
                    estado_eleccion = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true, defaultValue: "activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleccion", x => x.ideleccion);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    idpermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    accion = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    modulo = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    descripcion_permiso = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.idpermiso);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    idpersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero_identificacion = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    primer_nombre = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    segundo_nombre = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true),
                    primer_apellido = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    segundo_apellido = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true),
                    telefono = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true),
                    direccion = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.idpersona);
                });

            migrationBuilder.CreateTable(
                name: "Requisito",
                columns: table => new
                {
                    idrequisito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_requisito = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisito", x => x.idrequisito);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    idrol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_rol = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    descripcion_rol = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    estado_rol = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true, defaultValue: "activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.idrol);
                });

            migrationBuilder.CreateTable(
                name: "Convocatoria",
                columns: table => new
                {
                    idconvocatoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_convocatoria = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", maxLength: 255, nullable: false),
                    fecha_inicio_convocatoria = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    fecha_fin_convocatoria = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    idcargo = table.Column<int>(type: "int", nullable: false),
                    ideleccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convocatoria", x => x.idconvocatoria);
                    table.ForeignKey(
                        name: "FK_Convocatoria_Cargo_idcargo",
                        column: x => x.idcargo,
                        principalTable: "Cargo",
                        principalColumn: "idcargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Convocatoria_Eleccion_ideleccion",
                        column: x => x.ideleccion,
                        principalTable: "Eleccion",
                        principalColumn: "ideleccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idusuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_usuario = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    contrasena = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: false),
                    estado_usuario = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true, defaultValue: "inactivo"),
                    idpersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idusuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_idpersona",
                        column: x => x.idpersona,
                        principalTable: "Persona",
                        principalColumn: "idpersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolHasPermiso",
                columns: table => new
                {
                    idrol = table.Column<int>(type: "int", nullable: false),
                    idpermiso = table.Column<int>(type: "int", nullable: false),
                    estado_rol_permiso = table.Column<string>(type: "varchar(45) CHARACTER SET utf8mb4", maxLength: 45, nullable: true, defaultValue: "activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolHasPermiso", x => new { x.idrol, x.idpermiso });
                    table.ForeignKey(
                        name: "FK_RolHasPermiso_Permiso_idpermiso",
                        column: x => x.idpermiso,
                        principalTable: "Permiso",
                        principalColumn: "idpermiso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolHasPermiso_Rol_idrol",
                        column: x => x.idrol,
                        principalTable: "Rol",
                        principalColumn: "idrol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    idpersona = table.Column<int>(type: "int", nullable: false),
                    idconvocatoria = table.Column<int>(type: "int", nullable: false),
                    estado_participante = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    numero_participante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => new { x.idpersona, x.idconvocatoria });
                    table.ForeignKey(
                        name: "FK_Candidato_Convocatoria_idconvocatoria",
                        column: x => x.idconvocatoria,
                        principalTable: "Convocatoria",
                        principalColumn: "idconvocatoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidato_Persona_idpersona",
                        column: x => x.idpersona,
                        principalTable: "Persona",
                        principalColumn: "idpersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConvocatoriaRequisito",
                columns: table => new
                {
                    Convocatoriaidconvocatoria = table.Column<int>(type: "int", nullable: false),
                    Requisitoidrequisito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvocatoriaRequisito", x => new { x.Convocatoriaidconvocatoria, x.Requisitoidrequisito });
                    table.ForeignKey(
                        name: "FK_ConvocatoriaRequisito_Convocatoria_Convocatoriaidconvocatoria",
                        column: x => x.Convocatoriaidconvocatoria,
                        principalTable: "Convocatoria",
                        principalColumn: "idconvocatoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvocatoriaRequisito_Requisito_Requisitoidrequisito",
                        column: x => x.Requisitoidrequisito,
                        principalTable: "Requisito",
                        principalColumn: "idrequisito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    idrol = table.Column<int>(type: "int", nullable: false),
                    idusuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => new { x.idrol, x.idusuario });
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_idrol",
                        column: x => x.idrol,
                        principalTable: "Rol",
                        principalColumn: "idrol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_idusuario",
                        column: x => x.idusuario,
                        principalTable: "Usuario",
                        principalColumn: "idusuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoEleccion",
                columns: table => new
                {
                    Eleccionideleccion = table.Column<int>(type: "int", nullable: false),
                    Candidatoidpersona = table.Column<int>(type: "int", nullable: false),
                    Candidatoidconvocatoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoEleccion", x => new { x.Eleccionideleccion, x.Candidatoidpersona, x.Candidatoidconvocatoria });
                    table.ForeignKey(
                        name: "FK_CandidatoEleccion_Candidato_Candidatoidpersona_Candidatoidco~",
                        columns: x => new { x.Candidatoidpersona, x.Candidatoidconvocatoria },
                        principalTable: "Candidato",
                        principalColumns: new[] { "idpersona", "idconvocatoria" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoEleccion_Eleccion_Eleccionideleccion",
                        column: x => x.Eleccionideleccion,
                        principalTable: "Eleccion",
                        principalColumn: "ideleccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sufragante",
                columns: table => new
                {
                    idusuario = table.Column<int>(type: "int", nullable: false),
                    ideleccion = table.Column<int>(type: "int", nullable: false),
                    fecha_sufragio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Candidatoidpersona = table.Column<int>(type: "int", nullable: true),
                    Candidatoidconvocatoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sufragante", x => new { x.idusuario, x.ideleccion });
                    table.ForeignKey(
                        name: "FK_Sufragante_Candidato_Candidatoidpersona_Candidatoidconvocato~",
                        columns: x => new { x.Candidatoidpersona, x.Candidatoidconvocatoria },
                        principalTable: "Candidato",
                        principalColumns: new[] { "idpersona", "idconvocatoria" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sufragante_Eleccion_ideleccion",
                        column: x => x.ideleccion,
                        principalTable: "Eleccion",
                        principalColumn: "ideleccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sufragante_Usuario_idusuario",
                        column: x => x.idusuario,
                        principalTable: "Usuario",
                        principalColumn: "idusuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_idconvocatoria",
                table: "Candidato",
                column: "idconvocatoria");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoEleccion_Candidatoidpersona_Candidatoidconvocatoria",
                table: "CandidatoEleccion",
                columns: new[] { "Candidatoidpersona", "Candidatoidconvocatoria" });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_nombre_cargo",
                table: "Cargo",
                column: "nombre_cargo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Convocatoria_idcargo",
                table: "Convocatoria",
                column: "idcargo");

            migrationBuilder.CreateIndex(
                name: "IX_Convocatoria_ideleccion",
                table: "Convocatoria",
                column: "ideleccion");

            migrationBuilder.CreateIndex(
                name: "IX_ConvocatoriaRequisito_Requisitoidrequisito",
                table: "ConvocatoriaRequisito",
                column: "Requisitoidrequisito");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_numero_identificacion",
                table: "Persona",
                column: "numero_identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requisito_nombre_requisito",
                table: "Requisito",
                column: "nombre_requisito",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_nombre_rol",
                table: "Rol",
                column: "nombre_rol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolHasPermiso_idpermiso",
                table: "RolHasPermiso",
                column: "idpermiso");

            migrationBuilder.CreateIndex(
                name: "IX_Sufragante_Candidatoidpersona_Candidatoidconvocatoria",
                table: "Sufragante",
                columns: new[] { "Candidatoidpersona", "Candidatoidconvocatoria" });

            migrationBuilder.CreateIndex(
                name: "IX_Sufragante_ideleccion",
                table: "Sufragante",
                column: "ideleccion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idpersona",
                table: "Usuario",
                column: "idpersona");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_nombre_usuario",
                table: "Usuario",
                column: "nombre_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_idusuario",
                table: "UsuarioRol",
                column: "idusuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoEleccion");

            migrationBuilder.DropTable(
                name: "ConvocatoriaRequisito");

            migrationBuilder.DropTable(
                name: "RolHasPermiso");

            migrationBuilder.DropTable(
                name: "Sufragante");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "Requisito");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Convocatoria");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Eleccion");
        }
    }
}
