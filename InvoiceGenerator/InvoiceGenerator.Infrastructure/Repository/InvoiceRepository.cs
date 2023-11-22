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
    public class InvoiceRepository : IInvoiceRepository
	{

		private readonly InvoiceGeneratorDBContext _context;

		public InvoiceRepository(InvoiceGeneratorDBContext context)
		{
			_context = context;
		}


		public Invoice? Get(Expression<Func<Invoice, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<Invoice> query = _context.Set<Invoice>();
			if (filter != null)
			{
				query = query.Where(filter);
			}
			if (!string.IsNullOrWhiteSpace(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.FirstOrDefault();
		}

		public bool Exists(Expression<Func<Invoice, bool>>? filter = null)
		{
			IQueryable<Invoice> query = _context.Set<Invoice>();
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return query.Any();
		}

		public IEnumerable<Invoice> GetAll(Expression<Func<Invoice, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<Invoice> query = _context.Set<Invoice>();
			if(filter != null)
			{
				query = query.Where(filter);
			}
			if (!string.IsNullOrWhiteSpace(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.ToList();
		}

		public void Add(Invoice entity)
		{
			_context.Add(entity);
		}

		public void Remove(Invoice entity)
		{
			_context.Remove(entity);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Invoice entity)
		{
			_context.Update(entity);
		}
	}
}
