using Microsoft.EntityFrameworkCore;
using ReaTeknoloji.Data.Models;
using ReaTeknoloji.Data.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaTeknoloji.Data.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Resources.CONNECTION_STRING);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<Product>();
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
