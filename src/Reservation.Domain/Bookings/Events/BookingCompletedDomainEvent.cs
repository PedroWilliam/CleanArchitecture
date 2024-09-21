using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
