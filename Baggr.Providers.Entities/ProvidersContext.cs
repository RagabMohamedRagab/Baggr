using Baggr.Providers.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities
{
    public class ProvidersContext : DbContext, IProvidersContext
    {
        public ProvidersContext(DbContextOptions<ProvidersContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Provider>(e =>
            {
                e.HasIndex(prp => new { prp.Key }).IsUnique();
                e.HasIndex(prp => new { prp.ProviderName }).IsUnique();
            });
            modelBuilder.Entity<City>(e =>
            {
                e.HasIndex(prp => new { prp.Key }).IsUnique();
                e.HasIndex(prp => new { prp.CityName }).IsUnique();
            });
            modelBuilder.Entity<Shipment>(e =>
            {
                e.HasIndex(prp => new { prp.Key }).IsUnique();
                e.HasIndex(prp => new { prp.OrderReference }).IsUnique();
            });
        }

        public DbContext Instance => this;
        public DbSet<Provider> Providers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ProviderCity> ProviderCities { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ProviderInformation> ProviderInformations { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShipmentProduct> ShipmentProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<JTExpressZone> JTExpressZones { get; set; }
        public DbSet<JTExpressCity> JTExpressCities { get; set; }
    }
}
