using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreApiKurssi.Models
{
    public partial class documentationContext : DbContext
    {
        public documentationContext()
        {
        }

        public documentationContext(DbContextOptions<documentationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documentation> Documentations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HRPPOU8;Database=RestfulKurssi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Documentation>(entity =>
            {
                entity.ToTable("Documentation");

                entity.HasIndex(e => e.Keycode, "IX_Documentation")
                    .IsUnique();

                entity.Property(e => e.DocumentationId).HasColumnName("DocumentationID");

                entity.Property(e => e.AvailableRoute)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Keycode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
