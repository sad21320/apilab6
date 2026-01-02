namespace HotelBookingApi.Models;

public class Room
{
    public int RoomID { get; set; }
    public string RoomNumber { get; set; } = "";
    public int RoomTypeID { get; set; }
    public int Floor { get; set; }
    public string Status { get; set; } = "free";
    public DateTime CreatedDate { get; set; }

    public RoomType? RoomType { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}