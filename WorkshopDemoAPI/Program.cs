using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Data;
using WorkshopDemoAPI.Middleware;
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
builder.Services.AddScoped<IClientCreditSystem, ClientCreditSystem>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    // code runs here before next middleware is invoked
    await next.Invoke();
    // dode runs here after response is going back
});

app.UseCorrelationIdMiddleware();
app.UseClientCreditMiddleware();
// app.UseStaticFiles();
// app.UseCookiePolicy();
// app.UseRateLimiter();
// app.UseRequestLocalization();
// app.UseCors();

//app.UseAuthentication();
app.UseAuthorization();

// app.UseResponseCompression();
// app.UseResponseCaching();

app.MapControllers();

app.Run();
