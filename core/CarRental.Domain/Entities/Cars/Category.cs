using CarRental.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities.Cars
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Cars = new HashSet<Car>();
        }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
