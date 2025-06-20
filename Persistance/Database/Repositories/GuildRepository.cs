using Microsoft.EntityFrameworkCore;
using Persistance.Database.Entities;
using Persistance.Database.Interfaces.Repositories;

namespace Persistance.Database.Repositories;

public class GuildRepository : IGuildRepository
{
    private readonly LeagueDbContext _ldb;

    public GuildRepository(LeagueDbContext ldb)
    {
        _ldb = ldb;
    }

    public async Task<GuildEntity?> GetGuildAsync(ulong guildId, CancellationToken cts = default)
    {
        return await _ldb.Guilds.FirstOrDefaultAsync(x => x.GuildId == guildId, cts).ConfigureAwait(false);
    }

    public async Task<GuildEntity> CreateGuildAsync(ulong guildId, CancellationToken cts = default)
    {
        var guild = new GuildEntity
        {
            GuildId = guildId
        };
        
        await _ldb.Guilds.AddAsync(guild, cts).ConfigureAwait(false);
        await _ldb.SaveChangesAsync(cts).ConfigureAwait(false);
        
        return guild;
    }
}