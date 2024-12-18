
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ������ ������ ��� MVC �� ����������
builder.Services.AddControllers();

var app = builder.Build();

// ����������� ������������ ���������� API
app.MapControllers();

app.Run();
