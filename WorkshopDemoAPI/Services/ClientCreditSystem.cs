using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Data;

namespace WorkshopDemoAPI.Services;

public class ClientCreditSystem(WorkshopDemoDbContext dbContext) : IClientCreditSystem
{
    private readonly WorkshopDemoDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<bool> CheckClientCredit(string apiKey)
    {
        var key = await _dbContext
            .ApiKeys
            .Include(x => x.Client)
            .FirstOrDefaultAsync(x => x.Value == apiKey);

        if (key is null)
        {
            return false;
        }

        if (key.Client.CreditsRemaining <= 0)
        {
            return false;
        }
        
        key.Client.CreditsRemaining -= 1;
        _dbContext.ApiKeys.Update(key);
        await _dbContext.SaveChangesAsync();
            
        return true;

    }
}