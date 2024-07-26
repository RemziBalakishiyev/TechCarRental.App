using AutoMapper;
using CarRental.Application.Dtos;
using CarRental.Application.Interfaces;
using MediatR;

namespace CarRental.Application.Features.Querires;

public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IEnumerable<CarViewDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllCarQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async  Task<IEnumerable<CarViewDto>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        var cars = await _uow.CarRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CarViewDto>>(cars);
    }
}
