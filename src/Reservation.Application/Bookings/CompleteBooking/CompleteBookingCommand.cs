using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Bookings.CompleteBooking;

public record CompleteBookingCommand(Guid BookingId) : ICommand;