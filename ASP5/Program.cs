
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Додаємо служби для MVC та контролерів
builder.Services.AddControllers();

var app = builder.Build();

// Налаштовуємо використання контролерів API
app.MapControllers();

app.Run();
