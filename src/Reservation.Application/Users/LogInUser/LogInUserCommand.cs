using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Users.LogInUser;
public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<AccessTokenResponse>;
