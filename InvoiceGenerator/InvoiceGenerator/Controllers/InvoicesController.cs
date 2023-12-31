﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceGenerator.Domain;
using InvoiceGenerator.Infrastructure;
using InvoiceGenerator.Application.Common.Interfaces;

namespace InvoiceGenerator.Web.Controllers
{
    public class InvoicesController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;

		public InvoicesController(IUnitOfWork unitOfWork)
        {
			this._unitOfWork = unitOfWork;
		}

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            return View(_unitOfWork.Invoice.GetAll());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = _unitOfWork.Invoice.Get(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,EventName,Amount,EventDate,CreatedOn,CreatedBy")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
				_unitOfWork.Invoice.Add(invoice);
				_unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = _unitOfWork.Invoice.Get(p=>p.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,EventName,Amount,EventDate,CreatedOn,CreatedBy")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					_unitOfWork.Invoice.Update(invoice);
					_unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = _unitOfWork.Invoice.Get(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = _unitOfWork.Invoice.Get(p => p.Id == id);
            if (invoice != null)
            {
				_unitOfWork.Invoice.Remove(invoice);
            }

			_unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _unitOfWork.Invoice.Any(e => e.Id == id);
        }
    }
}
