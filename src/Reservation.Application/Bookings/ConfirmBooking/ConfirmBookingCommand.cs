using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Bookings.ConfirmBooking;

public sealed record ConfirmBookingCommand(Guid BookingId) : ICommand;