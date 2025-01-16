using CodeDesignPlus.Net.Logger.Extensions;
using CodeDesignPlus.Net.Mongo.Extensions;
using CodeDesignPlus.Net.RabbitMQ.Extensions;
using CodeDesignPlus.Net.Redis.Cache.Extensions;
using CodeDesignPlus.Net.Redis.Extensions;
using CodeDesignPlus.Net.Security.Extensions;
using CodeDesignPlus.Net.Vault.Extensions;

var builder = WebApplication.CreateSlimBuilder(args);

Serilog.Debugging.SelfLog.Enable(Console.Error);

builder.Host.UseSerilog();

builder.Configuration.AddVault();

builder.Services.AddVault(builder.Configuration);
builder.Services.AddMongo<Acme.Net.Microservice.Inventory.Infrastructure.Startup>(builder.Configuration);
builder.Services.AddRedis(builder.Configuration);
builder.Services.AddRabbitMQ<Program>(builder.Configuration);
builder.Services.AddSecurity(builder.Configuration);
builder.Services.AddCache(builder.Configuration);

var app = builder.Build();

var home = app.MapGroup("/home");

home.MapGet("/", () => "Ready");

await app.RunAsync();

public partial class Program
{
    protected Program() { }
}