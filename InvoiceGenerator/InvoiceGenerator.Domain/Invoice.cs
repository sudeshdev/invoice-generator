using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public required string CompanyName { get; set; }
        public required string EventName { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime EventDate { get; set; }

        public required DateTime CreatedOn { get; set; }
        public required int CreatedBy { get; set; }
    }
}
