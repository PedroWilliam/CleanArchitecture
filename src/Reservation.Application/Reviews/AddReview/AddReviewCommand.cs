using Reservation.Application.Abstractions.Messaging;

namespace Reservation.Application.Reviews.AddReview;

public sealed record AddReviewCommand(Guid BookingId, int Rating, string Comment) : ICommand;