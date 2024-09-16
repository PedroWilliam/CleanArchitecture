using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Bookings.GetBooking;
public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
