using AutoMapper;
using CarRental.Application.Exception;
using CarRental.Application.Extensions;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities.Cars;
using FluentValidation;
using MediatR;

namespace CarRental.Application.Features.Command
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddCarCommand> validationRules;
        public AddCarCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddCarCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            this.validationRules = validationRules;
        }
        public async Task Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            await validationRules.ThrowIfValidationFailAsync(request);
            var carEntity = _mapper.Map<Car>(request);
            await _uow.CarRepository.AddAsync(carEntity);
            await _uow.Commit();
        }
    }
}
