using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IntroduccionWebServices.API.Models
{
    public partial class WebServiceIntroContext : DbContext
    {
        public WebServiceIntroContext()
        {
        }

        public WebServiceIntroContext(DbContextOptions<WebServiceIntroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=WebServiceIntro;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .HasColumnName("APELLIDO")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(50);
            });
        }
    }
}
