using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIGestionDocumentos.Models;

namespace APIGestionDocumentos.Data
{
    public partial class GestionDocumentosContext : DbContext
    {
        public GestionDocumentosContext()
        {
        }

        public GestionDocumentosContext(DbContextOptions<GestionDocumentosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; } = null!;
        public virtual DbSet<Tramite> Tramites { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__document__40F9A207E296262C");

                entity.ToTable("documentos");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.TipoDocumento).HasColumnName("tipo_documento");

                entity.HasOne(d => d.TipoDocumentoNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.TipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_documentos");
            });

            modelBuilder.Entity<TiposDocumento>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__tipos_do__40F9A207FC888B1E");

                entity.ToTable("tipos_documentos");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tramite>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__tramites__40F9A20752FC5357");

                entity.ToTable("tramites");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.DocumentoNavigation)
                    .WithMany(p => p.Tramites)
                    .HasForeignKey(d => d.Documento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tramites");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
