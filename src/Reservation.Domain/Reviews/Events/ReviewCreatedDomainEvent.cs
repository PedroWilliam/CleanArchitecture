using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Reviews.Events;
public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
