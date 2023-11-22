using InvoiceGenerator.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Infrastructure.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly InvoiceGeneratorDBContext _context;

		public UnitOfWork(InvoiceGeneratorDBContext context)
        {
			this._context = context;
			Invoice = new InvoiceRepository(context);
		}

        public IInvoiceRepository Invoice { get; private set; }

		public void Save()
		{
			_context.SaveChanges();
		}

	}
}
