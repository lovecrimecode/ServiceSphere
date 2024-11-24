using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Core;
using ServiceSphere.Infrastructure.Interfaces;
using ServiceSphere.Infrastructure.Persistence.Context;

public class GuestRepository : BaseRepository<Guest>, IGuestRepository
{
    public GuestRepository(ServiceSphereDbContext context) : base(context) { }

    public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
    {
        return await _context.Guests.ToListAsync();
    }

    public async Task<Guest> GetGuestByIdAsync(int id)
    {
        return await _context.Guests.FindAsync(id);
    }

    public async Task AddGuestAsync(Guest GuestItem)
    {
        await _context.Guests.AddAsync(GuestItem);
        await _context.SaveChangesAsync();
    }

    public void UpdateGuest(Guest GuestItem)
    {
        _context.Guests.Update(GuestItem);
        _context.SaveChanges();
    }

    public void DeleteGuest(int id)
    {
        var GuestItem = _context.Guests.Find(id);
        if (GuestItem != null)
        {
            _context.Guests.Remove(GuestItem);
            _context.SaveChanges();
        }
    }
}
