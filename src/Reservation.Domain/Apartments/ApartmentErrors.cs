using Reservation.Domain.Abstractions;

namespace Reservation.Domain.Apartments;
public static class ApartmentErrors
{
    public static Error NotFound = new(
        "Apartment.NotFound",
        "The aparment with the specified identifier was not found");
}
