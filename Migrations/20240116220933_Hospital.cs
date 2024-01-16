using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class Hospital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    IdConsultorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_consultorio = table.Column<int>(type: "int", nullable: false),
                    direccion_consultorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono_consultorio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.IdConsultorio);
                });

            migrationBuilder.CreateTable(
                name: "especialidadMedicos",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEspecialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especialidadMedicos", x => x.IdEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_paciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_paciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    direccion_paciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo_paciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono_paciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado_paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "RecetaMedicas",
                columns: table => new
                {
                    IdReceta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dosis_medica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaMedicas", x => x.IdReceta);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosMedicos",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion_servicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_servicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado_servicio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosMedicos", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "ConsultaMedicas",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_examen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    serviciosmedicosIdServicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaMedicas", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_ConsultaMedicas_ServiciosMedicos_serviciosmedicosIdServicio",
                        column: x => x.serviciosmedicosIdServicio,
                        principalTable: "ServiciosMedicos",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado_cita = table.Column<int>(type: "int", nullable: false),
                    consultorioIdConsultorio = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ConsultaMedicaId = table.Column<int>(type: "int", nullable: false),
                    ConsultorioaId = table.Column<int>(type: "int", nullable: false),
                    RecetaMedicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Citas_ConsultaMedicas_ConsultaMedicaId",
                        column: x => x.ConsultaMedicaId,
                        principalTable: "ConsultaMedicas",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Consultorios_consultorioIdConsultorio",
                        column: x => x.consultorioIdConsultorio,
                        principalTable: "Consultorios",
                        principalColumn: "IdConsultorio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_RecetaMedicas_RecetaMedicaId",
                        column: x => x.RecetaMedicaId,
                        principalTable: "RecetaMedicas",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado_horario = table.Column<int>(type: "int", nullable: false),
                    citasIdCita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_Horarios_Citas_citasIdCita",
                        column: x => x.citasIdCita,
                        principalTable: "Citas",
                        principalColumn: "IdCita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_medico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitaIdCita = table.Column<int>(type: "int", nullable: false),
                    EspecialidadMedicoIdEspecialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medicos_Citas_CitaIdCita",
                        column: x => x.CitaIdCita,
                        principalTable: "Citas",
                        principalColumn: "IdCita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicos_especialidadMedicos_EspecialidadMedicoIdEspecialidad",
                        column: x => x.EspecialidadMedicoIdEspecialidad,
                        principalTable: "especialidadMedicos",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ConsultaMedicaId",
                table: "Citas",
                column: "ConsultaMedicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_consultorioIdConsultorio",
                table: "Citas",
                column: "consultorioIdConsultorio");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteId",
                table: "Citas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_RecetaMedicaId",
                table: "Citas",
                column: "RecetaMedicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaMedicas_serviciosmedicosIdServicio",
                table: "ConsultaMedicas",
                column: "serviciosmedicosIdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_citasIdCita",
                table: "Horarios",
                column: "citasIdCita");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_CitaIdCita",
                table: "Medicos",
                column: "CitaIdCita");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadMedicoIdEspecialidad",
                table: "Medicos",
                column: "EspecialidadMedicoIdEspecialidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "especialidadMedicos");

            migrationBuilder.DropTable(
                name: "ConsultaMedicas");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "RecetaMedicas");

            migrationBuilder.DropTable(
                name: "ServiciosMedicos");
        }
    }
}
