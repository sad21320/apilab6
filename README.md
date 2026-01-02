# HotelBookingApi

Лабораторная работа №6  
ASP.NET Core Web API — система бронирования отеля

## О проекте

Реализован REST API для управления бронированиями в отеле с клиентской HTML-страницей.

Основные возможности:
- Полный CRUD для сущности Bookings (бронирования)
- Swagger UI для просмотра и тестирования API
- Простая HTML-страница (index.html) с таблицей, формой создания/редактирования и кнопками удаления
- Отображение смысловых значений: ФИО гостя, номер комнаты, тип номера, даты, стоимость, статус
- Модульные тесты (xUnit + InMemory EF Core)

## Запуск локально

1. Откройте файл решения HotelBookingApi.sln в Visual Studio
2. Убедитесь, что в appsettings.json указана строка подключения к базе:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-8VL22MN\\SQLEXPRESS;Database=HotelBookingSystem;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}

3. Запустите проект (F5 или Ctrl+F5)
4. Откройте в браузере:
Swagger: https://localhost:7026/swagger
HTML-клиент: https://localhost:7026/index.html