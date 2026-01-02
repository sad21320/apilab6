using Microsoft.EntityFrameworkCore;
using HotelBookingApi.Models;

namespace HotelBookingApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<AdditionalService> AdditionalServices { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<InvoiceService> InvoiceServices { get; set; }  // ← добавили промежуточную таблицу

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Указываем точные имена таблиц (на случай расхождений)
        modelBuilder.Entity<RoomType>().ToTable("RoomTypes");
        modelBuilder.Entity<Room>().ToTable("Rooms");
        modelBuilder.Entity<Guest>().ToTable("Guests");
        modelBuilder.Entity<Booking>().ToTable("Bookings");
        modelBuilder.Entity<AdditionalService>().ToTable("AdditionalServices");
        modelBuilder.Entity<Invoice>().ToTable("Invoices");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<InvoiceService>().ToTable("InvoiceServices");

        // Первичные ключи (на всякий случай явно)
        modelBuilder.Entity<RoomType>().HasKey(rt => rt.RoomTypeID);
        modelBuilder.Entity<Room>().HasKey(r => r.RoomID);
        modelBuilder.Entity<Guest>().HasKey(g => g.GuestID);
        modelBuilder.Entity<Booking>().HasKey(b => b.BookingID);
        modelBuilder.Entity<AdditionalService>().HasKey(s => s.ServiceID);
        modelBuilder.Entity<Invoice>().HasKey(i => i.InvoiceID);
        modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeID);
        modelBuilder.Entity<InvoiceService>().HasKey(isrv => isrv.InvoiceServiceID);

        // Связи (Foreign Keys)

        // Room → RoomType
        // Все даты — datetime2 (диапазон 0001–9999, без проблем с MinValue)
        modelBuilder.Entity<Booking>()
            .Property(b => b.CheckinDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<Booking>()
            .Property(b => b.CheckoutDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<Booking>()
            .Property(b => b.CreatedDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<Guest>()
            .Property(g => g.CreatedDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<Room>()
            .Property(r => r.CreatedDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<RoomType>()
            .Property(rt => rt.CreatedDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<AdditionalService>()
            .Property(s => s.CreatedDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<Invoice>()
            .Property(i => i.CreatedDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<Employee>()
            .Property(e => e.HireDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<Employee>()
            .Property(e => e.CreatedDate)
            .HasColumnType("datetime2(7)");

        modelBuilder.Entity<InvoiceService>()
            .Property(isrv => isrv.CreatedDate)
            .HasColumnType("datetime2(7)");

        // Типы данных для decimal (важно для SQL Server)
        modelBuilder.Entity<RoomType>().Property(rt => rt.BasePrice).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Booking>().Property(b => b.TotalPrice).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<AdditionalService>().Property(s => s.Price).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Invoice>().Property(i => i.TotalAmount).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Employee>().Property(e => e.Salary).HasColumnType("decimal(18,2)");
    }
}