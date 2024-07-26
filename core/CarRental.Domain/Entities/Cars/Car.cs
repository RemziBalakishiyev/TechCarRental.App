using CarRental.Domain.Entities.Common;

namespace CarRental.Domain.Entities.Cars
{
    public class Car :  BaseEntity
    {
        public string CarName { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
