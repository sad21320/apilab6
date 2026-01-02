namespace HotelBookingApi.Models;

public class AdditionalService
{
    public int ServiceID { get; set; }
    public string ServiceName { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
}