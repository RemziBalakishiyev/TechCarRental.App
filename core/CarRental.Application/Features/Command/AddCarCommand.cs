using CarRental.Application.Mappers;
using CarRental.Domain.Entities.Cars;
using MediatR;

namespace CarRental.Application.Features.Command
{
    public class AddCarCommand : IMapTo<Car>,IRequest
    {
        public string CarName { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
