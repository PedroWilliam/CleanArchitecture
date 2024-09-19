using Microsoft.AspNetCore.Authorization;

namespace Reservation.Infrastructure.Authorization;
public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(permission)
    {
    }
}