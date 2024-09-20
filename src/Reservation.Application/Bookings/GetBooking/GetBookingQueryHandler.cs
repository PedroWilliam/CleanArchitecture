using Dapper;
using Reservation.Application.Abstractions.Authentication;
using Reservation.Application.Abstractions.Data;
using Reservation.Application.Abstractions.Messaging;
using Reservation.Domain.Abstractions;
using Reservation.Domain.Bookings;

namespace Reservation.Application.Bookings.GetBooking;
internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IUserContext _userContext;

    public GetBookingQueryHandler(
        ISqlConnectionFactory connectionFactory,
        IUserContext userContext)
    {
        _sqlConnectionFactory = connectionFactory;
        _userContext = userContext;
    }

    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var command = new CommandDefinition(
            """
            SELECT
                id AS Id,
                apartment_id AS ApartmentId,
                user_id AS UserId,
                status AS Status,
                price_for_period_amount AS PriceAmount,
                price_for_period_currency AS PriceCurrency,
                cleaning_fee_amount AS CleaningFeeAmount,
                cleaning_fee_currency AS CleaningFeeCurrency,
                amenities_up_charge_amount AS AmenitiesUpChargeAmount,
                amenities_up_charge_currency AS AmenitiesUpChargeCurrency,
                total_price_amount AS TotalPriceAmount,
                total_price_currency AS TotalPriceCurrency,
                duration_start AS DurationStart,
                duration_end AS DurationEnd,
                created_on_utc AS CreatedOnUtc
            FROM bookings
            WHERE id = @BookingId
            """,
            new
            {
                request.BookingId
            },
            cancellationToken: cancellationToken);

        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(command);

        if (booking is null || booking.UserId != _userContext.UserId)
        {
            return Result.Failure<BookingResponse>(BookingErrors.NotFound);
        }

        return booking;
    }
}
