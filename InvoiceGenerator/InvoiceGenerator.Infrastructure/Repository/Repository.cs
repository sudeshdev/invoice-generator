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
    public class Repository<T> : IRepository<T> where T : class
	{

		private readonly InvoiceGeneratorDBContext _context;
		internal DbSet<T> dbSet;

		public Repository(InvoiceGeneratorDBContext context)
		{
			_context = context;
			dbSet = _context.Set<T>();
		}


		public T? Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
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

		public bool Any(Expression<Func<T, bool>>? filter)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return query.Any();
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
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

		public void Add(T entity)
		{
			_context.Add(entity);
		}

		public void Remove(T entity)
		{
			_context.Remove(entity);
		}

	}
}
