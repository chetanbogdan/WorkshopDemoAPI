namespace WorkshopDemoAPI.Services;

public class MicrosoftEmailServiceProvider(ILogger<MicrosoftEmailServiceProvider> logger) : IEmailService
{
    private readonly ILogger<MicrosoftEmailServiceProvider> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public Task SendEmail(string emailText)
    {
        _logger.LogInformation($"Sending email with Microsoft Outlook. Email body:{emailText}");
        
        return Task.CompletedTask;
    }
}