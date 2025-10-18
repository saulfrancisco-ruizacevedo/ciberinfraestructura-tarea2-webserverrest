using Microsoft.EntityFrameworkCore;
using ciberinfraestructura_tarea2_webserver_rest.Models;

namespace ciberinfraestructura_tarea2_webserver_rest.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CatPersonal> CatPersonales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CatPersonal>(entity =>
            {
                entity.ToTable("CatPersonal");
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).HasColumnType("varchar(80)").IsRequired();
                entity.Property(e => e.cargo).HasColumnType("varchar(80)").IsRequired();
            });
        }
    }
}