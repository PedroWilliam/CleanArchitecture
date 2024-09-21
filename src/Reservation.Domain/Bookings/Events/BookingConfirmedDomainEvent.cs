using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Bookings.Events;
public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
