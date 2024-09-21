using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Bookings.RejectBooking;

public sealed record RejectBookingCommand(Guid BookingId) : ICommand;