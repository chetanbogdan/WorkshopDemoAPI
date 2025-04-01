using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Data;
using WorkshopDemoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WorkshopDemoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IEmailService, MailchimpEmailServiceProvider>();

builder.Services.AddSingleton<IGuidGeneratorSingleton, GuidGenerator>();
builder.Services.AddScoped<IGuidGeneratorScoped, GuidGenerator>();
builder.Services.AddTransient<IGuidGeneratorTransient, GuidGenerator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/now", ([FromServices]IGuidGeneratorSingleton guidSingleton,
    [FromServices]IGuidGeneratorScoped guidScoped1,
    [FromServices]IGuidGeneratorScoped guidScoped2,
    [FromServices]IGuidGeneratorTransient guidTransient1,
    [FromServices]IGuidGeneratorTransient guidTransient2) =>
{
    return $"Singleton instance: {guidSingleton.Value}\r\n\r\n" +
           $"Scoped instance 1: {guidScoped1.Value}\r\nScoped instance 2: {guidScoped2.Value}\r\n\r\n" +
           $"Transient instance 1: {guidTransient1.Value}\r\nTransient instance 2: {guidTransient2.Value}";
});

app.Run();
