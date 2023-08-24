using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.Entities
{
    public class Journey
    {
        public int ID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
