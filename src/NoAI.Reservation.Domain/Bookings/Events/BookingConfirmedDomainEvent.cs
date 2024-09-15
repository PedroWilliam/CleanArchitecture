using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
