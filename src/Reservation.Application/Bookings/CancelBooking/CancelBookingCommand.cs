using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Bookings.CancelBooking;

public record CancelBookingCommand(Guid BookingId) : ICommand;