namespace HotelBookingApi.Models;

public class RoomType
{
    public int RoomTypeID { get; set; }
    public string TypeName { get; set; } = "";      // ← TypeName (как в базе)
    public string Description { get; set; } = "";
    public int Capacity { get; set; }
    public decimal BasePrice { get; set; }
    public DateTime CreatedDate { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}