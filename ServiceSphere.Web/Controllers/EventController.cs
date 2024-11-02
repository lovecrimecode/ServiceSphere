﻿using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Application.Services;

[Route("events")]
public class EventController : Controller
{
    private readonly EventService _eventService;

    public EventController(EventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<IActionResult> Index()
    {
        var events = await _eventService.GetEventsAsync();
        return View(events);
    }

    public async Task<IActionResult> Details(int id)
    {
        var evento = await _eventService.GetEventByIdAsync(id);
        if (evento == null) return NotFound();
        return View(evento);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Event newEvent)
    {
        if (!ModelState.IsValid)
            return View(newEvent);

        await _eventService.CreateEventAsync(newEvent);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var evento = await _eventService.GetEventByIdAsync(id);
        if (evento == null) return NotFound();
        return View(evento);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Event updatedEvent)
    {
        if (!ModelState.IsValid)
            return View(updatedEvent);

        await _eventService.UpdateEventAsync(updatedEvent);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var evento = await _eventService.GetEventByIdAsync(id);
        if (evento == null) return NotFound();
        return View(evento);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _eventService.DeleteEventAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
