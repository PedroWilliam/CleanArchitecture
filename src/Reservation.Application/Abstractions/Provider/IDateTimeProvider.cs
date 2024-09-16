namespace Reservation.Application.Abstractions.Provider;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
