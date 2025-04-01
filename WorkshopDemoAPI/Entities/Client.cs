namespace WorkshopDemoAPI.Entities;

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();
    public int CreditsRemaining { get; set; }
    
}