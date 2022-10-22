using Service.Business.Abstract;
using Service.DataAccess.Abstract;
using Service.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.Concrete
{
    public class PartManager : IPartService
    {
        private readonly IPartDal _partDal;

        public PartManager(IPartDal partDal)
        {
            _partDal = partDal;
        }

        
    }
}
