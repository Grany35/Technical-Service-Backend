using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities.Dtos
{
    public class CreateServiceDto
    {
        public int CustomerId { get; set; }
        public string CustomerDescription { get; set; }
        public string FinalStatement { get; set; }
    }
}
