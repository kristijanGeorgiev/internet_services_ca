using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Fluel { get; set; }
        public int Power { get; set; }
        public virtual Client? client { get; set; }
        public int ClientId { get; set; }
    }
}
