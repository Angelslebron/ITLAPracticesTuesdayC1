using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecuresCompany.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEmpleado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    departamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    puesto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gerenteID = table.Column<int>(type: "int", nullable: true),
                    areaEspecializacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    presupuestoAnual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    numeroSubordinados = table.Column<int>(type: "int", nullable: true),
                    bonoGerencial = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    proyectosAsignados = table.Column<int>(type: "int", nullable: true),
                    nivelExperiencia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nivelTecnico = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    tareasPendientes = table.Column<int>(type: "int", nullable: true),
                    lineasCodigoMes = table.Column<int>(type: "int", nullable: true),
                    proyectosTI = table.Column<int>(type: "int", nullable: true),
                    equipoDesarrollo = table.Column<int>(type: "int", nullable: true),
                    bonoTecnico = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    empleadosAcargo = table.Column<int>(type: "int", nullable: true),
                    especialidadRRHH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vacantesActivas = table.Column<int>(type: "int", nullable: true),
                    contratacionesMes = table.Column<int>(type: "int", nullable: true),
                    departamentosSupervisa = table.Column<int>(type: "int", nullable: true),
                    bonoGestion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Gerente",
                        column: x => x.gerenteID,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CertificacionesEmpleado",
                columns: table => new
                {
                    CertificacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    NombreCertificacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaObtencion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificacionesEmpleado", x => x.CertificacionID);
                    table.ForeignKey(
                        name: "FK_CertificacionesEmpleado_Empleado",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroPoliza = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fechaIngreso = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    saldoPendiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tipoSeguro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tipoCliente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ultimoPago = table.Column<DateOnly>(type: "date", nullable: true),
                    descuentoFidelidad = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    mesesConsecutivosAlDia = table.Column<int>(type: "int", nullable: true),
                    diasMora = table.Column<int>(type: "int", nullable: true),
                    montoMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    recargoPorMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fechaUltimoAtraso = table.Column<DateOnly>(type: "date", nullable: true),
                    enProcesoCobro = table.Column<bool>(type: "bit", nullable: true),
                    motivoMora = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    verificacionCompletada = table.Column<bool>(type: "bit", nullable: true),
                    fechaProximaRevision = table.Column<DateOnly>(type: "date", nullable: true),
                    porcentajeCompletado = table.Column<int>(type: "int", nullable: true),
                    aprobacionPendiente = table.Column<bool>(type: "bit", nullable: true),
                    empleadoAsignadoID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    nombreCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_EmpleadoAsignado",
                        column: x => x.empleadoAsignadoID,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LenguajesProgramacionEmpleado",
                columns: table => new
                {
                    LenguajeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    NombreLenguaje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NivelDominio = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenguajesProgramacionEmpleado", x => x.LenguajeID);
                    table.ForeignKey(
                        name: "FK_LenguajesProgramacionEmpleado_Empleado",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosPendientes",
                columns: table => new
                {
                    documentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteID = table.Column<int>(type: "int", nullable: false),
                    nombreDocumento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosPendientes", x => x.documentoID);
                    table.ForeignKey(
                        name: "FK_DocumentosPendientes_cliente",
                        column: x => x.clienteID,
                        principalTable: "Clients",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificacionesEmpleado_Empleado",
                table: "CertificacionesEmpleado",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_empleadoAsignado",
                table: "Clients",
                column: "empleadoAsignadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_numeroPoliza",
                table: "Clients",
                column: "numeroPoliza");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_tipoCliente",
                table: "Clients",
                column: "tipoCliente");

            migrationBuilder.CreateIndex(
                name: "UQ_Clients_email",
                table: "Clients",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_Clients_numeroPoliza",
                table: "Clients",
                column: "numeroPoliza",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosPendientes_cliente",
                table: "DocumentosPendientes",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Departamento",
                table: "Empleados",
                column: "departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Gerente",
                table: "Empleados",
                column: "gerenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdEmpleado",
                table: "Empleados",
                column: "idEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Puesto",
                table: "Empleados",
                column: "puesto");

            migrationBuilder.CreateIndex(
                name: "UQ_Empleados_IdEmpleado",
                table: "Empleados",
                column: "idEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LenguajesProgramacionEmpleado_Empleado",
                table: "LenguajesProgramacionEmpleado",
                column: "EmpleadoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificacionesEmpleado");

            migrationBuilder.DropTable(
                name: "DocumentosPendientes");

            migrationBuilder.DropTable(
                name: "LenguajesProgramacionEmpleado");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
