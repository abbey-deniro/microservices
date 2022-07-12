using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ItemDB>(opt => opt.UseInMemoryDatabase("ItemList"));
var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
