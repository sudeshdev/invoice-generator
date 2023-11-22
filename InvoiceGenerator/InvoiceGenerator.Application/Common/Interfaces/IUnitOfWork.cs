using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Application.Common.Interfaces
{
	public interface IUnitOfWork
	{
        public IInvoiceRepository Invoice { get; }
		void Save();

	}
}
