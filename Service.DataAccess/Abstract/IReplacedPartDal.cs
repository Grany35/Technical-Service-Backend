using Service.Core.DataAccess;
using Service.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataAccess.Abstract
{
    public interface IReplacedPartDal : IEntityRepository<ReplacedPart>
    {
    }
}
