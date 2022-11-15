using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevoirPA.Entities
{
    public partial class devoirpaContext : DbContext
    {
        public devoirpaContext()
        {
        }

        public devoirpaContext(DbContextOptions<devoirpaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bureau> Bureau { get; set; }
        public virtual DbSet<Centre> Centre { get; set; }
        public virtual DbSet<Electeur> Electeur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=devoirpa");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bureau>(entity =>
            {
                entity.HasKey(e => e.Numero)
                    .HasName("PRIMARY");

                entity.ToTable("bureau");

                entity.HasIndex(e => e.Numeroelecteur, "numeroelecteur")
                    .IsUnique();

                entity.Property(e => e.Numero)
                    .HasColumnType("int(11)")
                    .HasColumnName("numero");

                entity.Property(e => e.Capacite)
                    .HasColumnType("int(11)")
                    .HasColumnName("capacite");

                entity.Property(e => e.Nom)
                    .HasMaxLength(25)
                    .HasColumnName("nom");

                entity.Property(e => e.Numeroelecteur)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("numeroelecteur");
            });

            modelBuilder.Entity<Centre>(entity =>
            {
                entity.HasKey(e => e.Nuumero)
                    .HasName("PRIMARY");

                entity.ToTable("centre");

                entity.HasIndex(e => e.Numerobureau, "numerobureau")
                    .IsUnique();

                entity.Property(e => e.Nuumero)
                    .HasColumnType("int(11)")
                    .HasColumnName("nuumero");

                entity.Property(e => e.Lieu)
                    .HasMaxLength(25)
                    .HasColumnName("lieu");

                entity.Property(e => e.Nom)
                    .HasMaxLength(25)
                    .HasColumnName("nom");

                entity.Property(e => e.Numerobureau)
                    .HasColumnType("int(11)")
                    .HasColumnName("numerobureau");
            });

            modelBuilder.Entity<Electeur>(entity =>
            {
                entity.HasKey(e => e.Numero)
                    .HasName("PRIMARY");

                entity.ToTable("electeur");

                entity.Property(e => e.Numero)
                    .HasMaxLength(25)
                    .HasColumnName("numero");

                entity.Property(e => e.Lieu)
                    .HasMaxLength(25)
                    .HasColumnName("lieu");

                entity.Property(e => e.Nom)
                    .HasMaxLength(25)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(25)
                    .HasColumnName("prenom");

                entity.Property(e => e.Ladate)
                    .HasColumnName("ladate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
