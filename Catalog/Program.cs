using Microsoft.EntityFrameworkCore;

var  policyName = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddDbContext<ItemDB>(opt => opt.UseInMemoryDatabase("ItemList"));
builder.Services.AddDbContext<ItemDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db1")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                    builder =>
                    {
                        builder
                            .WithOrigins("*") // specifying the allowed origin
                            .WithMethods("GET") // defining the allowed HTTP method
                            .AllowAnyHeader(); // allowing any header to be sent
                    });
});
var app = builder.Build();
app.UseCors(policyName);
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
