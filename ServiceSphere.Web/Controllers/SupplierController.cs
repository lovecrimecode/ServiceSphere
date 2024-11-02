using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Application.Services;

[Route("suppliers")]
public class SupplierController : Controller
{
    private readonly SupplierService _supplierService;

    public SupplierController(SupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    public async Task<IActionResult> Index()
    {
        var suppliers = await _supplierService.GetSuppliersAsync();
        return View(suppliers);
    }

    public async Task<IActionResult> Details(int id)
    {
        var supplier = await _supplierService.GetSupplierByIdAsync(id);
        if (supplier == null) return NotFound();
        return View(supplier);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Supplier newSupplier)
    {
        if (!ModelState.IsValid)
            return View(newSupplier);

        await _supplierService.CreateSupplierAsync(newSupplier);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var supplier = await _supplierService.GetSupplierByIdAsync(id);
        if (supplier == null) return NotFound();
        return View(supplier);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Supplier updatedSupplier)
    {
        if (!ModelState.IsValid)
            return View(updatedSupplier);

        await _supplierService.UpdateSupplierAsync(updatedSupplier);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var supplier = await _supplierService.GetSupplierByIdAsync(id);
        if (supplier == null) return NotFound();
        return View(supplier);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _supplierService.DeleteSupplierAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
