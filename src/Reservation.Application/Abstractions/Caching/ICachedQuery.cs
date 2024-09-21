using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Abstractions.Caching;
public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;

public interface ICachedQuery
{
    string CacheKey { get; }

    TimeSpan? Expiration { get; }
}