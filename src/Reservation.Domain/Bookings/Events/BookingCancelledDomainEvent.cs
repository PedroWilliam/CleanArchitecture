using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
