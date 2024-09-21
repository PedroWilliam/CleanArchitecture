using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
