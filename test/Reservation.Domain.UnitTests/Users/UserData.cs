﻿using Reservation.Domain.Users;

namespace Reservation.Domain.UnitTests.Users;

internal static class UserData
{
    public static readonly FirstName FirstName = new("First");
    public static readonly LastName LastName = new("Last");
    public static readonly Email Email = new("test@reservation.com");
}