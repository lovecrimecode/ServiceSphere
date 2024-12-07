﻿using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Application.Services;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SupplierService _supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return View(suppliers);
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var supplierItem = await _supplierService.GetSupplierByIdAsync(id.Value);
            if (supplierItem == null) return NotFound("Supplier not found.");
            return View(supplierItem);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierModel supplierModel)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.AddSupplierAsync(new Supplier
                {
                    Name = supplierModel.Name,
                    Contact = supplierModel.Contact
                });
                return RedirectToAction(nameof(Index));
            }
            return View(supplierModel);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var supplierItem = await _supplierService.GetSupplierByIdAsync(id.Value);
            if (supplierItem == null) return NotFound("Supplier not found.");

            var supplierModel = new SupplierModel
            {
                SupplierId = supplierItem.Id,
                Name = supplierItem.Name,
                Contact = supplierItem.Contact
            };

            return View(supplierModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupplierModel supplierModel)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.UpdateSupplierAsync(new Supplier
                {
                    Id = supplierModel.SupplierId,
                    Name = supplierModel.Name,
                    Contact = supplierModel.Contact
                });
                return RedirectToAction(nameof(Index));
            }
            return View(supplierModel);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var supplierItem = await _supplierService.GetSupplierByIdAsync(id.Value);
            if (supplierItem == null) return NotFound("Supplier not found.");
            return View(supplierItem);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}