using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
