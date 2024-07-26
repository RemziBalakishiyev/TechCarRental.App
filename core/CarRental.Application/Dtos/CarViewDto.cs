using CarRental.Application.Mappers;
using CarRental.Domain.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Dtos
{
    public class CarViewDto : IMapTo<Car>
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }
}
