using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Users.GetLoggedInUser;
public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;
