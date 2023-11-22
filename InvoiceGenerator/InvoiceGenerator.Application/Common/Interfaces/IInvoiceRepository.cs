using InvoiceGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Application.Common.Interfaces
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAll(Expression<Func<Invoice, bool>>? filter = null, string? includeProperties = null);
        Invoice? Get(Expression<Func<Invoice, bool>>? filter = null, string? includeProperties = null);
        bool Exists(Expression<Func<Invoice, bool>>? filter = null);
        void Add(Invoice entity);
        void Update(Invoice entity);
        void Remove(Invoice entity);
        void Save();
    }
}
