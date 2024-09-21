using Dapper;
using Reservation.Application.Abstractions.Authentication;
using Reservation.Application.Abstractions.Data;
using Reservation.Application.Abstractions.Messaging;
using Reservation.Domain.Abstractions;

namespace Reservation.Application.Users.GetLoggedInUser;
internal sealed class GetLoggedInUserQueryHandler
    : IQueryHandler<GetLoggedInUserQuery, UserResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IUserContext _userContext;

    public GetLoggedInUserQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IUserContext userContext)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _userContext = userContext;
    }

    public async Task<Result<UserResponse>> Handle(
        GetLoggedInUserQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var command = new CommandDefinition("""
            SELECT
                id AS Id,
                first_name AS FirstName,
                last_name AS LastName,
                email AS Email
            FROM users
            WHERE identity_id = @IdentityId
            """,
            new
            {
                _userContext.IdentityId
            },
            cancellationToken: cancellationToken);

        var user = await connection.QuerySingleAsync<UserResponse>(command);

        return user;
    }
}