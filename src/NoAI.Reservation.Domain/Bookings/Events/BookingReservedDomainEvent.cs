using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
