using InvoiceGenerator.Application.Common.Interfaces;
using InvoiceGenerator.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Infrastructure.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
	{

		private readonly InvoiceGeneratorDBContext _context;

		public InvoiceRepository(InvoiceGeneratorDBContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Invoice entity)
		{
			_context.Update(entity);
		}
	}
}
