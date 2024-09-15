using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Users.Events;
public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
