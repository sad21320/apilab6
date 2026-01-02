using System.Collections.Generic;

namespace HotelBookingApi.Models;

public class Invoice
{
    public int InvoiceID { get; set; }          // Первичный ключ
    public int BookingID { get; set; }          // Внешний ключ на Booking
    public int EmployeeID { get; set; }         // Внешний ключ на Employee
    public decimal TotalAmount { get; set; }    // Итоговая сумма
    public bool IsPaid { get; set; }            // Оплачено/нет
    public DateTime CreatedDate { get; set; }   // Дата создания

    // Навигационные свойства
    public Booking? Booking { get; set; }
    public Employee? Employee { get; set; }
    public ICollection<InvoiceService> InvoiceServices { get; set; } = new List<InvoiceService>();
}