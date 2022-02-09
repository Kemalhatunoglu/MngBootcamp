using Core.Security.Entities;
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
        public DbSet<Color> Colors { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<FindeksCredit> FindeksCredits { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DamageRecord> DamageRecords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")));
            //}
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
                m.ToTable("Models").HasKey(key => key.Id);
                m.Property(x => x.Id).HasColumnName("Id").IsRequired();
                m.Property(x => x.BrandId).HasColumnName("BrandId").IsRequired();
                m.Property(x => x.FuelId).HasColumnName("FuelId").IsRequired();
                m.Property(x => x.TransmissionId).HasColumnName("TransmissionId").IsRequired();
                m.Property(x => x.Name).HasColumnName("Name").IsRequired();
                m.Property(x => x.DailyPrice).HasColumnName("DailyPrice");
                m.Property(x => x.ImageUrl).HasColumnName("ImageUrl");
                m.HasMany(x => x.Cars);
                m.HasOne(x => x.Fuel);
                m.HasOne(x => x.Transmission);

            });

            modelBuilder.Entity<Car>(c =>
            {
                c.ToTable("Cars").HasKey(key => key.Id);
                c.Property(x => x.Id).HasColumnName("Id").IsRequired();
                c.Property(x => x.ModelId).HasColumnName("ModelId").IsRequired();
                c.Property(x => x.ColorId).HasColumnName("ColorId").IsRequired();
                c.Property(x => x.CityId).HasColumnName("CityId").IsRequired();
                c.Property(x => x.Plate).HasColumnName("Plate").IsRequired();
                c.Property(x => x.ModelYear).HasColumnName("ModelYear");
                c.Property(x => x.CarState).HasColumnName("State");
                c.Property(x => x.MaintainStartDate).HasColumnName("MaintainStartDate");
                c.Property(x => x.MaintainEndDate).HasColumnName("MaintainEndDate");
                c.HasOne(x => x.Model);
                c.HasOne(x => x.Color);
            });

            modelBuilder.Entity<Color>(c =>
            {
                c.ToTable("Colors").HasKey(key => key.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.Name).HasColumnName("Name").IsRequired();
                c.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Fuel>(b =>
            {
                b.ToTable("Fuels").HasKey(key => key.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name").IsRequired();
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Transmission>(b =>
            {
                b.ToTable("Transmissions").HasKey(key => key.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name").IsRequired();
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Rental>(r =>
            {
                r.ToTable("Rentals").HasKey(key => key.Id);
                r.Property(p => p.Id).HasColumnName("Id");
                r.Property(p => p.CarId).HasColumnName("CarId").IsRequired();
                r.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired();
                r.Property(p => p.StartDate).HasColumnName("StartDate").IsRequired();
                r.Property(p => p.EndDate).HasColumnName("EndDate").IsRequired();
                r.Property(p => p.ReturnDate).HasColumnName("ReturnDate").IsRequired();
                r.HasOne(p => p.Car);
            });

            modelBuilder.Entity<CorporateCustomer>(corp =>
            {
                corp.ToTable("CorporateCustomers").HasKey(key => key.Id);
                corp.Property(p => p.Id).HasColumnName("Id");
                corp.Property(p => p.Email).HasColumnName("Email").IsRequired();
                corp.Property(p => p.Phone).HasColumnName("Phone").IsRequired();
                corp.Property(p => p.CompanyName).HasColumnName("CompanyName").IsRequired();
                corp.Property(p => p.TaxNo).HasColumnName("TaxNo").IsRequired();
                corp.Property(p => p.FindeksRate).HasColumnName("FindeksRate").IsRequired();
                corp.HasMany(p => p.Rentals);
            });

            modelBuilder.Entity<IndividualCustomer>(indivi =>
            {
                indivi.ToTable("IndividualCustomers").HasKey(key => key.Id);
                indivi.Property(p => p.Id).HasColumnName("Id");
                indivi.Property(p => p.Email).HasColumnName("Email").IsRequired();
                indivi.Property(p => p.Phone).HasColumnName("Phone").IsRequired();
                indivi.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
                indivi.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
                indivi.Property(p => p.NationalIdentity).HasColumnName("NationalIdentity").IsRequired();
                indivi.Property(p => p.FindeksRate).HasColumnName("FindeksRate").IsRequired();
            });

            modelBuilder.Entity<FindeksCredit>(b =>
            {
                b.ToTable("FindeksCredits").HasKey(key => key.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired();
                b.Property(p => p.CustomerType).HasColumnName("CustomerType").IsRequired();
                b.Property(p => p.Score).HasColumnName("Score").IsRequired();
            });

            modelBuilder.Entity<Invoice>(inv =>
            {
                inv.ToTable("Invoices").HasKey(key => key.Id);
                inv.Property(p => p.Id).HasColumnName("Id");
                inv.Property(p => p.InvoiceNo).HasColumnName("InvoiceNo").IsRequired();
                inv.Property(p => p.CreationDate).HasColumnName("CreationDate").IsRequired();
                inv.Property(p => p.RentalStartDate).HasColumnName("RentalStartDate").IsRequired();
                inv.Property(p => p.RentalEndDate).HasColumnName("RetuRentalEndDaternDate").IsRequired();
                inv.Property(p => p.RentalDayCount).HasColumnName("RentalDayCount").IsRequired();
                inv.Property(p => p.TotalFee).HasColumnName("TotalFee").IsRequired();
                inv.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired();
                inv.Property(p => p.CustomerType).HasColumnName("CustomerType").IsRequired();
                inv.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<City>(city =>
            {
                city.ToTable("Cities").HasKey(key => key.Id);
                city.Property(p => p.Id).HasColumnName("Id");
                city.Property(p => p.Name).HasColumnName("Name");
                city.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<DamageRecord>(b =>
            {
                b.ToTable("DamageRecords").HasKey(key => key.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.CarId).HasColumnName("CarId").IsRequired();
                b.Property(p => p.DamageExp).HasColumnName("DamageExp").IsRequired();
                b.HasOne(p => p.Car);
            });

            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("Users").HasKey(key => key.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
                b.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
                b.Property(p => p.Email).HasColumnName("Email").IsRequired();
                b.Property(p => p.PasswordHash).HasColumnName("CaPasswordHashrId").IsRequired();
                b.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
                b.Property(p => p.Status).HasColumnName("Status").IsRequired();
            });

            modelBuilder.Entity<OperationClaim>(b =>
            {
                b.ToTable("OperationClaims").HasKey(key => key.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name").IsRequired();

            });

            modelBuilder.Entity<UserOperationClaim>(b =>
            {
                b.ToTable("UserOperationClaims").HasKey(key => key.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.UserId).HasColumnName("UserId").IsRequired();
                b.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
                b.HasMany(x => x.OperationClaims);
                b.HasOne(x => x.User);

            });

            //var brand1 = new Brand(1, "BMW");
            //var brand2 = new Brand(2, "Mercedes");
            //modelBuilder.Entity<Brand>().HasData(brand1, brand2);

            //var color1 = new Color(1, "Red");
            //var color2 = new Color(2, "Blue");
            //modelBuilder.Entity<Color>().HasData(color1, color2);

            //var transmissions1 = new Transmission(1, "Manuel");
            //var transmissions2 = new Transmission(2, "Automatic");
            //modelBuilder.Entity<Transmission>().HasData(transmissions1, transmissions2);

            //var fuel1 = new Fuel(1, "Gas");
            //var fuel2 = new Fuel(2, "Diesel");
            //modelBuilder.Entity<Fuel>().HasData(fuel1, fuel2);

            //var model1 = new Model(1, 1, 2, 1, "418i", 1000, "1.jpg");
            //var model2 = new Model(2, 2, 1, 2, "CLA 180D", 1000, "2.jpg");
            //modelBuilder.Entity<Model>().HasData(model1, model2);

            //var car1 = new Car(1, 1, 2, "34BVC789", 2020, Domain.Enums.CarState.Available);
            //var car2 = new Car(2, 2, 1, "34DDD789", 2022, Domain.Enums.CarState.Rented);
            //modelBuilder.Entity<Car>().HasData(car1, car2);
        }
    }
}