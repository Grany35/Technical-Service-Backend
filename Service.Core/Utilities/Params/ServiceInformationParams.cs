using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Utilities.Params
{
    public class ServiceInformationParams : PaginationParams
    {
        public bool? IsActive { get; set; }
    }
}
