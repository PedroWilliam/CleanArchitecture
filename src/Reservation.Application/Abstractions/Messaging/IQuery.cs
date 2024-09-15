using MediatR;
using Reservation.Domain.Abstractions;

namespace Reservation.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
