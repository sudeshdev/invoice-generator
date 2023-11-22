using InvoiceGenerator.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Infrastructure
{
    public class InvoiceGeneratorDBContext : DbContext
    {
        public InvoiceGeneratorDBContext(DbContextOptions<InvoiceGeneratorDBContext> options) : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    //        modelBuilder.Entity<Invoice>().HasData(
				//new Invoice { EventName = "Event 1", CompanyName = "Company 1", Amount = 2000, EventDate = new DateTime(2023, 11, 1), CreatedBy = 1, CreatedOn = DateTime.Now, Id = 1 },
				//new Invoice { EventName = "Event 2", CompanyName = "Company 2", Amount = 1000, EventDate = new DateTime(2023, 11, 2), CreatedBy = 1, CreatedOn = DateTime.Now, Id = 2 },
				//new Invoice { EventName = "Event 3", CompanyName = "Company 1", Amount = 4000, EventDate = new DateTime(2023, 11, 5), CreatedBy = 1, CreatedOn = DateTime.Now, Id = 3 },
				//new Invoice { EventName = "Event 4", CompanyName = "Company 2", Amount = 6000, EventDate = new DateTime(2023, 12, 1), CreatedBy = 1, CreatedOn = DateTime.Now, Id = 4 });
        }
    }
}
