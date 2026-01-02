namespace HotelBookingApi.Models;

public class Booking
{
    public int BookingID { get; set; }          // ← BookingID (как в базе)
    public int GuestID { get; set; }
    public int RoomID { get; set; }
    public DateTime CheckinDate { get; set; }   // ← CheckinDate (как в базе)
    public DateTime CheckoutDate { get; set; }  // ← CheckoutDate
    public decimal TotalPrice { get; set; }     // ← TotalPrice (как в базе)
    public string Status { get; set; } = "confirmed";
    public DateTime CreatedDate { get; set; }

    public Guest? Guest { get; set; }
    public Room? Room { get; set; }
}