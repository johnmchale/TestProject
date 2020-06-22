using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "John", AddressLine1 = "1 High St", AddressLine2 = "Burton", AddressLine3 = "UK" },
                new Customer { CustomerId = 2, Name = "Michael", AddressLine1 = "2 High St", AddressLine2 = "Burton", AddressLine3 = "UK" },
                new Customer { CustomerId = 3, Name = "Steven", AddressLine1 = "3 High St", AddressLine2 = "Burton", AddressLine3 = "UK" }
            );

            // n.b. the use of anonymous type 
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, Date = new DateTime(2018, 12, 29), OrderState = "Pending", CustomerId = 1 },
                new Order { OrderId = 2, Date = new DateTime(2019, 12, 30), OrderState = "Approved", CustomerId = 1 },
                new Order { OrderId = 3, Date = new DateTime(2020, 12, 31), OrderState = "Cancelled", CustomerId = 2 }
            );
        }
    }
}


