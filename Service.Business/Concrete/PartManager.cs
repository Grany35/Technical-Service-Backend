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

        public void Add(Part part)
        {
            _partDal.Add(part);
        }

        public void Delete(int partId)
        {
            var part = _partDal.Get(x => x.Id == partId);
            _partDal.Delete(part);
        }

        public async Task<List<Part>> GetAllAsync()
        {
            var parts = await _partDal.GetAllAsync();
            return parts;
        }

        public async Task<Part> GetByIdAsync(int partId)
        {
            var part = await _partDal.GetAsync(x => x.Id == partId);
            return part;
        }

        public void Update(Part part)
        {
            _partDal.Update(part);
        }
    }
}
