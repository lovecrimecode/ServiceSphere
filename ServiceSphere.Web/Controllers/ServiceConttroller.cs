using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Application.Services;

[Route("services")]
public class ServiceController : Controller
{
    private readonly ServiceService _serviceService;

    public ServiceController(ServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<IActionResult> Index()
    {
        var services = await _serviceService.GetServicesAsync();
        return View(services);
    }

    public async Task<IActionResult> Details(int id)
    {
        var service = await _serviceService.GetServiceByIdAsync(id);
        if (service == null) return NotFound();
        return View(service);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Service newService)
    {
        if (!ModelState.IsValid)
            return View(newService);

        await _serviceService.CreateServiceAsync(newService);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var service = await _serviceService.GetServiceByIdAsync(id);
        if (service == null) return NotFound();
        return View(service);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Service updatedService)
    {
        if (!ModelState.IsValid)
            return View(updatedService);

        await _serviceService.UpdateServiceAsync(updatedService);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var service = await _serviceService.GetServiceByIdAsync(id);
        if (service == null) return NotFound();
        return View(service);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _serviceService.DeleteServiceAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
