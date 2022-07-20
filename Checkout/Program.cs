var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/tester", () => { return "Hello from tester in checkout";});

app.Run();
