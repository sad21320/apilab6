namespace HotelBookingApi.Models;

public class Employee
{
    public int EmployeeID { get; set; }         // Первичный ключ
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }      // Дата приёма на работу
    public decimal Salary { get; set; }         // Зарплата
    public DateTime CreatedDate { get; set; }   // Дата создания записи

    // Навигационное свойство (если нужно)
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}