using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaMigracion.Models
{
    public partial class EquiposPelotaContext : DbContext
    {
        public EquiposPelotaContext()
        {
        }

        public EquiposPelotaContext(DbContextOptions<EquiposPelotaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Jugador> Jugadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=EquiposPelota;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.IdEquipo)
                    .HasName("PK__Equipos__4B9119C056238ECC");

                entity.Property(e => e.IdEquipo).HasColumnName("Id_Equipo");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__AB2EB6F89E5B78F2");

                entity.ToTable("Estado");

                entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.IdJugador)
                    .HasName("PK__Jugadore__A38193BEC738D33F");

                entity.Property(e => e.IdJugador).HasColumnName("Id_Jugador");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pasaporte)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.EquipoJ)
                    .WithMany(p => p.Jugadores)
                    .HasForeignKey(d => d.Equipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jugadores__Equip__32E0915F");

                entity.HasOne(d => d.EstadoJ)
                    .WithMany(p => p.Jugadores)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jugadores__Estad__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
