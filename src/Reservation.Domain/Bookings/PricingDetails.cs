using Reservation.Domain.Shared;

namespace Reservation.Domain.Bookings;
public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);
