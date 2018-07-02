using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using VehicleSystem.Api.Models;

namespace VehicleSystem.Api.Database
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext()
        {
        }

        public VehicleDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasKey(f => f.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

            new ConfigurationBuilder().Build();
            optionsBuilder.UseNpgsql(connectionString, (Action<NpgsqlDbContextOptionsBuilder>) null);
        }
    }
}