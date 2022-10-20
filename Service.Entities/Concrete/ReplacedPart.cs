using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities.Concrete
{
    public class ReplacedPart
    {
        public int Id { get; set; }
        public List<Part> Parts  { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
