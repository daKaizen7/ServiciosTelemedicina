using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiciosTelemedicina.Models;

public partial class TelemedicinaDbContext : DbContext
{
    public TelemedicinaDbContext()
    {
    }

    public TelemedicinaDbContext(DbContextOptions<TelemedicinaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradores { get; set; }

    public virtual DbSet<Antecedente> Antecedentes { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Diagnostico> Diagnosticos { get; set; }

    public virtual DbSet<HistoriasClinica> HistoriasClinicas { get; set; }

    public virtual DbSet<Informe> Informes { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Notificacion> Notificaciones { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<PermisosAdministrador> PermisosAdministradores { get; set; }

    public virtual DbSet<Terapeuta> Terapeutas { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-STB8RDG;Database=TelemedicinaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("Id_usuario");

            modelBuilder.Entity<Administrador>().ToTable("Administradores");
            modelBuilder.Entity<Administrador>().HasBaseType<Usuario>();
        });

        modelBuilder.Entity<Antecedente>(entity =>
        {
            entity.HasKey(e => e.IdAntecedente).HasName("PK__Antecede__56EEE240370C2B6E");

            entity.Property(e => e.IdAntecedente).HasColumnName("Id_antecedente");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdHistClin).HasColumnName("Id_hist_clin");

            entity.HasOne(d => d.IdHistClinNavigation).WithMany(p => p.Antecedentes)
                .HasForeignKey(d => d.IdHistClin)
                .HasConstraintName("FK__Anteceden__Id_hi__59FA5E80");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__Citas__5E31E370E302828F");

            entity.Property(e => e.IdCita).HasColumnName("Id_cita");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IdPaciente).HasColumnName("Id_paciente");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__Citas__Id_pacien__48CFD27E");
        });

        modelBuilder.Entity<Diagnostico>(entity =>
        {
            entity.HasKey(e => e.IdDiagnostico).HasName("PK__Diagnost__D18EAF9FF264A041");

            entity.Property(e => e.IdDiagnostico).HasColumnName("Id_diagnostico");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IdCita).HasColumnName("Id_cita");
            entity.Property(e => e.IdTerapeuta).HasColumnName("Id_terapeuta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.IdCita)
                .HasConstraintName("FK__Diagnosti__Id_ci__4E88ABD4");

            entity.HasOne(d => d.IdTerapeutaNavigation).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.IdTerapeuta)
                .HasConstraintName("FK__Diagnosti__Id_te__4D94879B");
        });

        modelBuilder.Entity<HistoriasClinica>(entity =>
        {
            entity.HasKey(e => e.IdHistClin).HasName("PK__Historia__3CAC02F14E3017EA");

            entity.ToTable("Historias_Clinicas");

            entity.Property(e => e.IdHistClin).HasColumnName("Id_hist_clin");
            entity.Property(e => e.IdDiagnostico).HasColumnName("Id_diagnostico");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_paciente");
            entity.Property(e => e.IdTratamiento).HasColumnName("Id_tratamiento");

            entity.HasOne(d => d.IdDiagnosticoNavigation).WithMany(p => p.HistoriasClinicas)
                .HasForeignKey(d => d.IdDiagnostico)
                .HasConstraintName("FK__Historias__Id_di__5629CD9C");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.HistoriasClinicas)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__Historias__Id_pa__5535A963");

            entity.HasOne(d => d.IdTratamientoNavigation).WithMany(p => p.HistoriasClinicas)
                .HasForeignKey(d => d.IdTratamiento)
                .HasConstraintName("FK__Historias__Id_tr__571DF1D5");
        });

        modelBuilder.Entity<Informe>(entity =>
        {
            entity.HasKey(e => e.IdInforme).HasName("PK__Informes__E545C5DB16D6866A");

            entity.Property(e => e.IdInforme).HasColumnName("Id_informe");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdHistClin).HasColumnName("Id_hist_clin");

            entity.HasOne(d => d.IdHistClinNavigation).WithMany(p => p.Informes)
                .HasForeignKey(d => d.IdHistClin)
                .HasConstraintName("FK__Informes__Id_his__5CD6CB2B");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento).HasName("PK__Medicame__391D9D47826F42DF");

            entity.Property(e => e.IdMedicamento).HasColumnName("Id_medicamento");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__2ED2DED3771FB348");

            entity.Property(e => e.IdNotificacion).HasColumnName("Id_notificacion");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Notificac__Id_us__45F365D3");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("Id_usuario");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            modelBuilder.Entity<Paciente>().HasBaseType<Usuario>();
        });

        modelBuilder.Entity<PermisosAdministrador>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK_PermisoAdministradores");

            entity.Property(e => e.IdAdmin)
                .ValueGeneratedNever()
                .HasColumnName("Id_admin");
            entity.Property(e => e.Permiso)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAdminNavigation).WithOne(p => p.PermisosAdministradore)
                .HasForeignKey<PermisosAdministrador>(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermisosA__Id_ad__3D5E1FD2");
        });

        modelBuilder.Entity<Terapeuta>(entity =>
        {
            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("Id_usuario");
            entity.Property(e => e.Cargo)
                .HasMaxLength(30)
                .IsUnicode(false);

            modelBuilder.Entity<Terapeuta>().ToTable("Terapeutas");
            modelBuilder.Entity<Terapeuta>().HasBaseType<Usuario>();
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTratamiento).HasName("PK__Tratamie__BF7D0DDCCB1EFACE");

            entity.Property(e => e.IdTratamiento).HasColumnName("Id_tratamiento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IdDiagnostico).HasColumnName("Id_diagnostico");
            entity.Property(e => e.IdMedicamento).HasColumnName("Id_medicamento");

            entity.HasOne(d => d.IdDiagnosticoNavigation).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.IdDiagnostico)
                .HasConstraintName("FK__Tratamien__Id_di__5165187F");

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.IdMedicamento)
                .HasConstraintName("FK__Tratamien__Id_me__52593CB8");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__EF59F762F74DA0D2");

            entity.HasIndex(e => e.Cedula, "UQ__Usuarios__B4ADFE38897EE255").IsUnique();

            entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd().HasColumnName("Id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
