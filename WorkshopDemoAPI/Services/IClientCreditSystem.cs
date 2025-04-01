namespace WorkshopDemoAPI.Services;

public interface IClientCreditSystem
{
    Task<bool> CheckClientCredit(string apiKey);
}