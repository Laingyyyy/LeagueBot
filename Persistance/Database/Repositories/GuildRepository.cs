using Microsoft.EntityFrameworkCore;
using Persistance.Database.Exceptions;
using Shared.Database.Interfaces;
using Shared.Database.Models.Discord;

namespace Persistance.Database.Repositories;

public class GuildRepository : IGuildRepository
{
    private readonly DiscordContext _context;
    
    public GuildRepository(DiscordContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a guild by its unique identifier. If the guild is not found,
    /// a <see cref="GuildNotFound"/> exception is thrown.
    /// </summary>
    /// <param name="guildId">The unique identifier of the guild to retrieve.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The <see cref="Guild"/> object associated with the specified identifier.</returns>
    /// <exception cref="GuildNotFound">Thrown when no guild is found with the specified identifier.</exception>
    public async Task<Guild> GetGuild(ulong guildId, CancellationToken cancellationToken = default)
    {
        return await _context.Guilds.FirstOrDefaultAsync(g => g.GuildId == guildId, cancellationToken) ??
                    throw new GuildNotFound(guildId);
    }

    /// <summary>
    /// Adds a new guild to the database and returns the added entity.
    /// </summary>
    /// <param name="guild">The <see cref="Guild"/> object to be added to the database.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>The newly added <see cref="Guild"/> object.</returns>
    public async Task<Guild> AddGuild(Guild guild, CancellationToken cancellationToken = default)
    {
        var newGuild = await _context.Guilds.AddAsync(guild, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        return newGuild.Entity;
    }

    /// <summary>
    /// Removes a guild from the persistent storage.
    /// </summary>
    /// <param name="guild">The <see cref="Guild"/> object to remove.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the removal operation to complete.</param>
    /// <returns>The removed <see cref="Guild"/> object.</returns>
    public async Task<Guild> RemoveGuild(Guild guild, CancellationToken cancellationToken = default)
    {
        var removedGuild = _context.Guilds.Remove(guild);
        
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        return removedGuild.Entity;
    }
}