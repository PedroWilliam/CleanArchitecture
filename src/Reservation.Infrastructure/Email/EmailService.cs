﻿using Reservation.Application.Abstractions.Email;

namespace Reservation.Infrastructure.Email;
internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
