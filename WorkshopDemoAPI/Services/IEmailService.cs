namespace WorkshopDemoAPI.Services;

public interface IEmailService
{
    Task SendEmail(string emailText);
}