using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
