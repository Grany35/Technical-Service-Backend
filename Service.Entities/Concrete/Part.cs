using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities.Concrete
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceDollar { get; set; }
        public decimal PriceTl { get; set; }
    }
}
