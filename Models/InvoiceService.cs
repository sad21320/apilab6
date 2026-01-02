namespace HotelBookingApi.Models;

public class InvoiceService
{
    public int InvoiceServiceID { get; set; }   // Первичный ключ
    public int InvoiceID { get; set; }          // Внешний ключ на Invoice
    public int ServiceID { get; set; }          // Внешний ключ на AdditionalService
    public int Quantity { get; set; }           // Количество
    public DateTime CreatedDate { get; set; }   // Дата создания

    // Навигационные свойства (опционально)
    public Invoice? Invoice { get; set; }
    public AdditionalService? AdditionalService { get; set; }
}