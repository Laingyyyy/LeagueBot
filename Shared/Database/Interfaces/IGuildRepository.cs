using Shared.Database.Models.Discord;

namespace Shared.Database.Interfaces;

public interface IGuildRepository
{
    public Task<Guild> GetGuild(ulong guildId, CancellationToken cancellationToken = default);
    public Task<Guild> AddGuild(Guild guildId, CancellationToken cancellationToken = default);
    public Task<Guild> RemoveGuild(Guild guildId, CancellationToken cancellationToken = default);
}