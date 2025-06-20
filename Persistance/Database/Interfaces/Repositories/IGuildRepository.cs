using Persistance.Database.Entities;

namespace Persistance.Database.Interfaces.Repositories;

public interface IGuildRepository
{
    /// <summary>
    /// Retrieves a guild entity by its unique identifier.
    /// </summary>
    /// <param name="guildId">The unique identifier of the guild to retrieve.</param>
    /// <param name="cts">Optional cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A Task representing the asynchronous operation. The result contains the matching guild entity, or null if not found.</returns>
    public Task<GuildEntity?> GetGuildAsync(ulong guildId, CancellationToken cts = default);

    /// <summary>
    /// Creates a new guild entity with the specified unique identifier.
    /// </summary>
    /// <param name="guildId">The unique identifier for the guild to be created.</param>
    /// <param name="cts">Optional cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A Task representing the asynchronous operation. The result contains the created guild entity.</returns>
    public Task<GuildEntity> CreateGuildAsync(ulong guildId, CancellationToken cts = default);
}