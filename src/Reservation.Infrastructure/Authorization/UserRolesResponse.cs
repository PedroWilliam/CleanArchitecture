using Reservation.Domain.Users;

namespace Reservation.Infrastructure.Authorization;
public class UserRolesResponse
{
    public Guid UserId { get; init; }

    public List<Role> Roles { get; init; } = [];
}
