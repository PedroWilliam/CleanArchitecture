using FluentAssertions;
using Reservation.Domain.Bookings;
using Reservation.Domain.Bookings.Events;
using Reservation.Domain.Shared;
using Reservation.Domain.UnitTests.Apartments;
using Reservation.Domain.UnitTests.Infrastructure;
using Reservation.Domain.UnitTests.Users;
using Reservation.Domain.Users;

namespace Reservation.Domain.UnitTests.Bookings;
public class BookingTests : BaseTest
{
    [Fact]
    public void Reserve_Should_RaiseBookingReservedDomainEvent()
    {
        // Arrange
        var user = User.Create(UserData.FirstName, UserData.LastName, UserData.Email);
        var price = new Money(10.0m, Currency.Usd);
        var duration = DateRange.Create(new DateOnly(2024, 1, 1), new DateOnly(2024, 1, 10));
        var apartment = ApartmentData.Create(price);
        var pricingService = new PricingService();

        // Act
        var booking = Booking.Reserve(apartment, user.Id, duration, DateTime.UtcNow, pricingService);

        // Assert
        var bookingReservedDomainEvent = AssertDomainEventWasPublished<BookingReservedDomainEvent>(booking);

        bookingReservedDomainEvent.BookingId.Should().Be(booking.Id);
    }
}
