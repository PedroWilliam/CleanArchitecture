﻿using Reservation.Domain.Users;

namespace Reservation.Application.Abstractions.Authentication;
public interface IAuthenticationService
{
    Task<string> RegisterAsync(User user, string password, CancellationToken cancellationToken = default);
}
