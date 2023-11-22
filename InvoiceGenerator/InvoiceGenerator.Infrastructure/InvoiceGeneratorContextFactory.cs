using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Infrastructure
{
    public class InvoiceGeneratorContextFactory : IDesignTimeDbContextFactory<InvoiceGeneratorDBContext>
    {
        public InvoiceGeneratorDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvoiceGeneratorDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=InvoiceGenerator; Trusted_Connection=True; MultipleActiveResultSets=True");

            return new InvoiceGeneratorDBContext(optionsBuilder.Options);
        }
    }
}
