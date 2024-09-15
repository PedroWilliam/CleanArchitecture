using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
