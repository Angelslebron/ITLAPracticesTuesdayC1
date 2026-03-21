using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SecuresCompany.API.Data.Entities;

namespace SecuresCompany.API.Data;

public partial class SecureCompanyContext : DbContext
{
    public SecureCompanyContext()
    {
    }

    public SecureCompanyContext(DbContextOptions<SecureCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CertificacionesEmpleado> CertificacionesEmpleados { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DocumentosPendiente> DocumentosPendientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<LenguajesProgramacionEmpleado> LenguajesProgramacionEmpleados { get; set; }
    public object Client { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=SecureCompany;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CertificacionesEmpleado>(entity =>
        {
            entity.HasKey(e => e.CertificacionId);

            entity.ToTable("CertificacionesEmpleado");

            entity.HasIndex(e => e.EmpleadoId, "IX_CertificacionesEmpleado_Empleado");

            entity.Property(e => e.CertificacionId).HasColumnName("CertificacionID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.NombreCertificacion).HasMaxLength(100);

            entity.HasOne(d => d.Empleado).WithMany(p => p.CertificacionesEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_CertificacionesEmpleado_Empleado");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClienteId);

            entity.HasIndex(e => e.EmpleadoAsignadoId, "IX_Clients_empleadoAsignado");

            entity.HasIndex(e => e.NumeroPoliza, "IX_Clients_numeroPoliza");

            entity.HasIndex(e => e.TipoCliente, "IX_Clients_tipoCliente");

            entity.HasIndex(e => e.Email, "UQ_Clients_email").IsUnique();

            entity.HasIndex(e => e.NumeroPoliza, "UQ_Clients_numeroPoliza").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.AprobacionPendiente).HasColumnName("aprobacionPendiente");
            entity.Property(e => e.DescuentoFidelidad)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("descuentoFidelidad");
            entity.Property(e => e.DiasMora).HasColumnName("diasMora");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmpleadoAsignadoId).HasColumnName("empleadoAsignadoID");
            entity.Property(e => e.EnProcesoCobro).HasColumnName("enProcesoCobro");
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.FechaProximaRevision).HasColumnName("fechaProximaRevision");
            entity.Property(e => e.FechaUltimoAtraso).HasColumnName("fechaUltimoAtraso");
            entity.Property(e => e.MesesConsecutivosAlDia).HasColumnName("mesesConsecutivosAlDia");
            entity.Property(e => e.MontoMora)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("montoMora");
            entity.Property(e => e.MotivoMora)
                .HasMaxLength(255)
                .HasColumnName("motivoMora");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.NumeroPoliza)
                .HasMaxLength(50)
                .HasColumnName("numeroPoliza");
            entity.Property(e => e.PorcentajeCompletado).HasColumnName("porcentajeCompletado");
            entity.Property(e => e.RecargoPorMora)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("recargoPorMora");
            entity.Property(e => e.SaldoPendiente)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("saldoPendiente");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(20)
                .HasColumnName("tipoCliente");
            entity.Property(e => e.TipoSeguro)
                .HasMaxLength(50)
                .HasColumnName("tipoSeguro");
            entity.Property(e => e.UltimoPago).HasColumnName("ultimoPago");
            entity.Property(e => e.VerificacionCompletada).HasColumnName("verificacionCompletada");

            entity.HasOne(d => d.EmpleadoAsignado).WithMany(p => p.Clients)
                .HasForeignKey(d => d.EmpleadoAsignadoId)
                .HasConstraintName("FK_Clientes_EmpleadoAsignado");
        });

        modelBuilder.Entity<DocumentosPendiente>(entity =>
        {
            entity.HasKey(e => e.DocumentoId);

            entity.HasIndex(e => e.ClienteId, "IX_DocumentosPendientes_cliente");

            entity.Property(e => e.DocumentoId).HasColumnName("documentoID");
            entity.Property(e => e.ClienteId).HasColumnName("clienteID");
            entity.Property(e => e.NombreDocumento)
                .HasMaxLength(100)
                .HasColumnName("nombreDocumento");

            entity.HasOne(d => d.Cliente).WithMany(p => p.DocumentosPendientes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_DocumentosPendientes_cliente");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasIndex(e => e.Departamento, "IX_Empleados_Departamento");

            entity.HasIndex(e => e.GerenteId, "IX_Empleados_Gerente");

            entity.HasIndex(e => e.IdEmpleado, "IX_Empleados_IdEmpleado");

            entity.HasIndex(e => e.Puesto, "IX_Empleados_Puesto");

            entity.HasIndex(e => e.IdEmpleado, "UQ_Empleados_IdEmpleado").IsUnique();

            entity.Property(e => e.EmpleadoId).HasColumnName("empleadoID");
            entity.Property(e => e.AreaEspecializacion)
                .HasMaxLength(50)
                .HasColumnName("areaEspecializacion");
            entity.Property(e => e.BonoGerencial)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bonoGerencial");
            entity.Property(e => e.BonoGestion)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bonoGestion");
            entity.Property(e => e.BonoTecnico)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bonoTecnico");
            entity.Property(e => e.ContratacionesMes).HasColumnName("contratacionesMes");
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .HasColumnName("departamento");
            entity.Property(e => e.DepartamentosSupervisa).HasColumnName("departamentosSupervisa");
            entity.Property(e => e.EmpleadosAcargo).HasColumnName("empleadosAcargo");
            entity.Property(e => e.EquipoDesarrollo).HasColumnName("equipoDesarrollo");
            entity.Property(e => e.EspecialidadRrhh)
                .HasMaxLength(50)
                .HasColumnName("especialidadRRHH");
            entity.Property(e => e.fechaIngreso).HasColumnName("fechaIngreso");
            entity.Property(e => e.GerenteId).HasColumnName("gerenteID");
            entity.Property(e => e.IdEmpleado)
                .HasMaxLength(50)
                .HasColumnName("idEmpleado");
            entity.Property(e => e.LineasCodigoMes).HasColumnName("lineasCodigoMes");
            entity.Property(e => e.NivelExperiencia)
                .HasMaxLength(20)
                .HasColumnName("nivelExperiencia");
            entity.Property(e => e.NivelTecnico)
                .HasMaxLength(20)
                .HasColumnName("nivelTecnico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroSubordinados).HasColumnName("numeroSubordinados");
            entity.Property(e => e.PresupuestoAnual)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("presupuestoAnual");
            entity.Property(e => e.ProyectosAsignados).HasColumnName("proyectosAsignados");
            entity.Property(e => e.ProyectosTi).HasColumnName("proyectosTI");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .HasColumnName("puesto");
            entity.Property(e => e.SalarioBase)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("salarioBase");
            entity.Property(e => e.TareasPendientes).HasColumnName("tareasPendientes");
            entity.Property(e => e.VacantesActivas).HasColumnName("vacantesActivas");

            entity.HasOne(d => d.Gerente).WithMany(p => p.InverseGerente)
                .HasForeignKey(d => d.GerenteId)
                .HasConstraintName("FK_Empleados_Gerente");
        });

        modelBuilder.Entity<LenguajesProgramacionEmpleado>(entity =>
        {
            entity.HasKey(e => e.LenguajeId);

            entity.ToTable("LenguajesProgramacionEmpleado");

            entity.HasIndex(e => e.EmpleadoId, "IX_LenguajesProgramacionEmpleado_Empleado");

            entity.Property(e => e.LenguajeId).HasColumnName("LenguajeID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.NivelDominio).HasMaxLength(20);
            entity.Property(e => e.NombreLenguaje).HasMaxLength(50);

            entity.HasOne(d => d.Empleado).WithMany(p => p.LenguajesProgramacionEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_LenguajesProgramacionEmpleado_Empleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
