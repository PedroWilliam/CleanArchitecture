﻿namespace Reservation.Domain.Apartments;
public record Address (
    string Country,
    string State,
    string ZipCode,
    string City,
    string StreetName,
    string StreetNumber);
