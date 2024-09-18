namespace Reservation.Infrastructure.Authentication;
public sealed class AuthenticationOptions
{
    public string Audience { get; init; } = default!;
    public string ValidIssuer { get; init; } = default!;
    public string MetadataUrl { get; init; } = default!;
    public bool RequireHttpsMetadata { get; init; }
}
