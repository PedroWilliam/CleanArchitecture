using Reservation.Application.Abstractions.Provider;

namespace Reservation.Infrastructure.Providers;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
