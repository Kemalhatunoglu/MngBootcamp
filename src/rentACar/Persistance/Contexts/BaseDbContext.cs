using Domain.Entities.Concete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistance
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brands").HasKey(key => key.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name").IsRequired();
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Model>(m =>
            {
                m.ToTable("Brands").HasKey(key => key.Id);
                m.Property(x => x.Id).HasColumnName("Id").IsRequired();
                m.Property(x => x.BrandId).HasColumnName("BrandId").IsRequired();
                m.Property(x => x.FuelId).HasColumnName("FuelId").IsRequired();
                m.Property(x => x.TransmissionId).HasColumnName("TransmissionId").IsRequired();
                m.Property(x => x.Name).HasColumnName("Name").IsRequired();
                m.Property(x => x.DailyPrice).HasColumnName("DailyPrice");
                m.Property(x => x.ImageUrl).HasColumnName("ImageUrl");
                m.HasMany(x => x.Cars);
            });

            modelBuilder.Entity<Car>(c =>
            {
                c.ToTable("Cars").HasKey(key => key.Id);
                c.Property(x => x.Id).HasColumnName("Id").IsRequired();
                c.Property(x => x.ModelId).HasColumnName("ModelId").IsRequired();
                c.Property(x => x.ColorId).HasColumnName("ColorId").IsRequired();
                c.Property(x => x.Plate).HasColumnName("Plate").IsRequired();
                c.Property(x => x.ModelYear).HasColumnName("ModelYear");
            });

        }
    }
}