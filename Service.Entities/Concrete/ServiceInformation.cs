using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities.Concrete
{
    public class ServiceInformation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerDescription { get; set; }
        public bool Status { get; set; } = true;
        public string? FinalStatement { get; set; }
        public List<ReplacedPart> ReplacedParts { get; set; }
    }
}
