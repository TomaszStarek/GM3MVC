using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace tutorial.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AwarieGm3> AwarieGm3s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<AwarieGm3>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("awarieGM3");

                entity.Property(e => e.CzasStart)
                    .HasColumnType("datetime")
                    .HasColumnName("czas_start");

                entity.Property(e => e.CzasStop)
                    .HasColumnType("datetime")
                    .HasColumnName("czas_stop");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Komentarz).HasColumnName("komentarz");

                entity.Property(e => e.Min)
                    .HasMaxLength(10)
                    .HasColumnName("min")
                    .IsFixedLength(true);

                entity.Property(e => e.Opis).HasColumnName("opis");

                entity.Property(e => e.Sekcja)
                    .HasMaxLength(10)
                    .HasColumnName("sekcja")
                    .IsFixedLength(true);

                entity.Property(e => e.Stacja)
                    .HasMaxLength(50)
                    .HasColumnName("stacja");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
