using InvoiceGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Application.Common.Interfaces
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        void Update(Invoice entity);
    }
}
