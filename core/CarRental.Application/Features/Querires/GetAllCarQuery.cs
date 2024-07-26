using CarRental.Application.Dtos;
using MediatR;

namespace CarRental.Application.Features.Querires
{
    public class GetAllCarQuery : IRequest<IEnumerable<CarViewDto>>
    {
    }
}
