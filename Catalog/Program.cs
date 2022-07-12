using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddDbContext<ItemDB>(opt => opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddDbContext<ItemDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db2")));
var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
