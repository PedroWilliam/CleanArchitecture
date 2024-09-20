using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Reservation.Application.Abstractions.Caching;
using System.Buffers;
using System.Text.Json;

namespace Reservation.Infrastructure.Caching;
internal sealed class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default)
    {
        byte[]? cacheKeyBytes = await _cache.GetAsync(cacheKey, cancellationToken);

        return cacheKeyBytes is null
            ? default
            : DeserializeCache<T>(cacheKeyBytes);
    }

    public Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default)
    {
        return _cache.RemoveAsync(cacheKey, cancellationToken);
    }

    public Task SetAsync<T>(
        string cacheKey,
        T value, TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
    {
        byte[] bytes = Serialize(value);

        return _cache.SetAsync(cacheKey, bytes, CacheOptions.Create(expiration), cancellationToken);
    }

    private static T DeserializeCache<T>(byte[] cacheKeyBytes)
    {
        return JsonSerializer.Deserialize<T>(cacheKeyBytes)!;
    }

    private static byte[] Serialize<T>(T value)
    {
        var buffer = new ArrayBufferWriter<byte>();

        using var writer = new Utf8JsonWriter(buffer);

        JsonSerializer.Serialize(writer, value);

        return buffer.WrittenSpan.ToArray();
    }
}
