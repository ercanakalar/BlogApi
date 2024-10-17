using Blog;

var builder = WebApplication.CreateBuilder(args);

var start = new Start();

var services = builder.Services;

start.ConfigureServices(services, builder);

var app = builder.Build();

var webHostEnvironment = app.Environment;

start.Configure(app, webHostEnvironment);

app.Run();



