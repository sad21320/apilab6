using HotelBookingApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. Регистрация DbContext — обязательно!
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));

// 2. Контроллеры + JSON без циклов
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.MaxDepth = 64;
    });

// 3. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. CORS — для HTML-клиента
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();   // Детальные ошибки в браузере

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelBookingApi v1");
        c.RoutePrefix = "swagger";     // Swagger будет по /swagger
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

// ← Самое главное! Без этой строки wwwroot не работает
app.UseStaticFiles();  // ← обслуживает index.html, css, js из wwwroot

app.UseAuthorization();
app.MapControllers();

// Редирект с корня на Swagger (удобно)
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();