namespace WorkshopDemoAPI.Entities;

public class ApiKey
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    
    public Client Client { get; set; } = null!;
    public string Value { get; set; } = null!;
    public bool IsDisabled { get; set; }
}