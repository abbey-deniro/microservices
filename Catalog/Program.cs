using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Discovery;

var  policyName = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDiscoveryClient(builder.Configuration);
//builder.Services.AddDbContext<ItemDB>(opt => opt.UseInMemoryDatabase("ItemList"));
builder.Services.AddDbContext<ItemDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db2")));
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

app.MapGet("/test", async (IDiscoveryClient idc) =>
{
    //return "this is the root of dotnet-eureka-client";
    DiscoveryHttpClientHandler _handler = new DiscoveryHttpClientHandler(idc);
    var client = new HttpClient(_handler, false);
    string response = await client.GetStringAsync("http://MICROSERVICES-2/checkout/tester") + " more from dotnet-api2";
    return response;
}
);

app.Run();
//https://localhost:7011;