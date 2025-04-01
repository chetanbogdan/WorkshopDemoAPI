namespace WorkshopDemoAPI.Services;

public class MailchimpEmailServiceProvider(ILogger<MailchimpEmailServiceProvider> logger) : IEmailService
{
    private readonly ILogger<MailchimpEmailServiceProvider> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public Task SendEmail(string emailText)
    {
        _logger.LogInformation($"Sending email with Mailchimp provider. Email body:{emailText}");
        
        return Task.CompletedTask;
    }
}