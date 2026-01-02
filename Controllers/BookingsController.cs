using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingApi.Data;
using HotelBookingApi.Models;

namespace HotelBookingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Bookings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        return await _context.Bookings
            .Include(b => b.Guest)
            .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
            .ToListAsync();
    }

    // GET: api/Bookings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Guest)
            .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
            .FirstOrDefaultAsync(b => b.BookingID == id);  // ← BookingID

        if (booking == null) return NotFound();
        return booking;
    }

    // POST: api/Bookings
    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingID }, booking);
    }

    // PUT: api/Bookings/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBooking(int id, Booking booking)
    {
        if (id != booking.BookingID) return BadRequest();  // ← BookingID
        _context.Entry(booking).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Bookings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null) return NotFound();
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // GET: api/Bookings/guests — список гостей для выпадающего списка
    [HttpGet("guests")]
    public async Task<ActionResult<IEnumerable<object>>> GetGuests()
    {
        return await _context.Guests
            .Select(g => new
            {
                g.GuestID,
                FullName = $"{g.FirstName} {g.LastName} {g.MiddleName}".Trim()
            })
            .ToListAsync();
    }

    // GET: api/Bookings/rooms — список номеров для выпадающего списка
    [HttpGet("rooms")]
    public async Task<ActionResult<IEnumerable<object>>> GetRooms()
    {
        return await _context.Rooms
            .Include(r => r.RoomType)
            .Select(r => new
            {
                r.RoomID,
                r.RoomNumber,
                RoomTypeName = r.RoomType != null ? r.RoomType.TypeName : null
            })
            .ToListAsync();
    }
}