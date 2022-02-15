using Application;
using Core.Application.Pipelines.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Mailing;
using Core.Mailing.MailkitImplementations;
using Infrastructure;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddSingleton<IMailService, MailkitMailService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options => options.AddDefaultPolicy(b =>
{
    b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

//builder.Services.AddDistributedMemoryCache();in memory çalýþýr hale gelir.
builder.Services.AddStackExchangeRedisCache(option => option.Configuration = "localhost:6379");
builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("CacheSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
