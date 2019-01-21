using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace SystemetAPI.Models
{
    public partial class VRContext : DbContext
    {
        public VRContext()
        {
        }

        public VRContext(DbContextOptions<VRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysSortTable> SysSortTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:krypt0r.database.windows.net,1433;Initial Catalog=VR;Persist Security Info=False;User ID=Victor;Password=*WlJe3wp7!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysSortTable>(entity =>
            {
                entity.HasKey(e => e.Nr);

                entity.Property(e => e.Nr)
                    .HasColumnName("nr")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alkoholhalt).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.ArtikelId).HasColumnName("ArtikelID");

                entity.Property(e => e.Forpackning)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Forslutning).HasMaxLength(50);

                entity.Property(e => e.Land)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Leverantör).HasMaxLength(100);

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Namn2).HasMaxLength(100);

                entity.Property(e => e.PrisInkMoms).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrisPerLiter).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Producent)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Saljstart).HasColumnType("date");

                entity.Property(e => e.Sortiment)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.SortimentText)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Stil).HasMaxLength(100);

                entity.Property(e => e.Typ).HasMaxLength(100);

                entity.Property(e => e.Ursprung)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Varugrupp).HasMaxLength(100);

                entity.Property(e => e.VolymIml).HasColumnType("decimal(10, 2)");
            });
        }
    }
}
