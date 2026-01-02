using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingApi.Data;
using HotelBookingApi.Models;

namespace HotelBookingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Rooms
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetRooms()
    {
        return await _context.Rooms
            .Include(r => r.RoomType)
            .Select(r => new
            {
                r.RoomID,
                r.RoomNumber,
                RoomTypeName = r.RoomType != null ? r.RoomType.TypeName : null,
                r.Floor,
                r.Status
            })
            .ToListAsync();
    }
}