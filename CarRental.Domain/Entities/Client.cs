using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
