using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiciosTelemedicina.Migrations
{
    /// <inheritdoc />
    public partial class TestMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id_medicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medicame__391D9D47826F42DF", x => x.Id_medicamento);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__EF59F762F74DA0D2", x => x.Id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__EF59F762F74DA0D2", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_Administradores_Usuarios_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id_notificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_usuario = table.Column<int>(type: "int", nullable: true),
                    Mensaje = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__2ED2DED3771FB348", x => x.Id_notificacion);
                    table.ForeignKey(
                        name: "FK__Notificac__Id_us__45F365D3",
                        column: x => x.Id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__EF59F762F74DA0D2", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terapeutas",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__EF59F762F74DA0D2", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_Terapeutas_Usuarios_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermisosAdministradores",
                columns: table => new
                {
                    Id_admin = table.Column<int>(type: "int", nullable: false),
                    Permiso = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoAdministradores", x => x.Id_admin);
                    table.ForeignKey(
                        name: "FK__PermisosA__Id_ad__3D5E1FD2",
                        column: x => x.Id_admin,
                        principalTable: "Administradores",
                        principalColumn: "Id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id_cita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_paciente = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Citas__5E31E370E302828F", x => x.Id_cita);
                    table.ForeignKey(
                        name: "FK__Citas__Id_pacien__48CFD27E",
                        column: x => x.Id_paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    Id_diagnostico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_terapeuta = table.Column<int>(type: "int", nullable: true),
                    Id_cita = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Diagnost__D18EAF9FF264A041", x => x.Id_diagnostico);
                    table.ForeignKey(
                        name: "FK__Diagnosti__Id_ci__4E88ABD4",
                        column: x => x.Id_cita,
                        principalTable: "Citas",
                        principalColumn: "Id_cita");
                    table.ForeignKey(
                        name: "FK__Diagnosti__Id_te__4D94879B",
                        column: x => x.Id_terapeuta,
                        principalTable: "Terapeutas",
                        principalColumn: "Id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    Id_tratamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_diagnostico = table.Column<int>(type: "int", nullable: true),
                    Id_medicamento = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tratamie__BF7D0DDCCB1EFACE", x => x.Id_tratamiento);
                    table.ForeignKey(
                        name: "FK__Tratamien__Id_di__5165187F",
                        column: x => x.Id_diagnostico,
                        principalTable: "Diagnosticos",
                        principalColumn: "Id_diagnostico");
                    table.ForeignKey(
                        name: "FK__Tratamien__Id_me__52593CB8",
                        column: x => x.Id_medicamento,
                        principalTable: "Medicamentos",
                        principalColumn: "Id_medicamento");
                });

            migrationBuilder.CreateTable(
                name: "Historias_Clinicas",
                columns: table => new
                {
                    Id_hist_clin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_paciente = table.Column<int>(type: "int", nullable: true),
                    Id_diagnostico = table.Column<int>(type: "int", nullable: true),
                    Id_tratamiento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historia__3CAC02F14E3017EA", x => x.Id_hist_clin);
                    table.ForeignKey(
                        name: "FK__Historias__Id_di__5629CD9C",
                        column: x => x.Id_diagnostico,
                        principalTable: "Diagnosticos",
                        principalColumn: "Id_diagnostico");
                    table.ForeignKey(
                        name: "FK__Historias__Id_pa__5535A963",
                        column: x => x.Id_paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id_usuario");
                    table.ForeignKey(
                        name: "FK__Historias__Id_tr__571DF1D5",
                        column: x => x.Id_tratamiento,
                        principalTable: "Tratamientos",
                        principalColumn: "Id_tratamiento");
                });

            migrationBuilder.CreateTable(
                name: "Antecedentes",
                columns: table => new
                {
                    Id_antecedente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_hist_clin = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Antecede__56EEE240370C2B6E", x => x.Id_antecedente);
                    table.ForeignKey(
                        name: "FK__Anteceden__Id_hi__59FA5E80",
                        column: x => x.Id_hist_clin,
                        principalTable: "Historias_Clinicas",
                        principalColumn: "Id_hist_clin");
                });

            migrationBuilder.CreateTable(
                name: "Informes",
                columns: table => new
                {
                    Id_informe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_hist_clin = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Informes__E545C5DB16D6866A", x => x.Id_informe);
                    table.ForeignKey(
                        name: "FK__Informes__Id_his__5CD6CB2B",
                        column: x => x.Id_hist_clin,
                        principalTable: "Historias_Clinicas",
                        principalColumn: "Id_hist_clin");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antecedentes_Id_hist_clin",
                table: "Antecedentes",
                column: "Id_hist_clin");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_paciente",
                table: "Citas",
                column: "Id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_Id_cita",
                table: "Diagnosticos",
                column: "Id_cita");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_Id_terapeuta",
                table: "Diagnosticos",
                column: "Id_terapeuta");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_Clinicas_Id_diagnostico",
                table: "Historias_Clinicas",
                column: "Id_diagnostico");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_Clinicas_Id_paciente",
                table: "Historias_Clinicas",
                column: "Id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_Clinicas_Id_tratamiento",
                table: "Historias_Clinicas",
                column: "Id_tratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Informes_Id_hist_clin",
                table: "Informes",
                column: "Id_hist_clin");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_Id_usuario",
                table: "Notificaciones",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_Id_diagnostico",
                table: "Tratamientos",
                column: "Id_diagnostico");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_Id_medicamento",
                table: "Tratamientos",
                column: "Id_medicamento");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__B4ADFE38897EE255",
                table: "Usuarios",
                column: "Cedula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antecedentes");

            migrationBuilder.DropTable(
                name: "Informes");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "PermisosAdministradores");

            migrationBuilder.DropTable(
                name: "Historias_Clinicas");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Terapeutas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
