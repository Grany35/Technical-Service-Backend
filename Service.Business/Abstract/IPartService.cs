using Service.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.Abstract
{
    public interface IPartService
    {
        void Add(Part part);
        void Delete(int partId);
        void Update(Part part);
        Task<List<Part>> GetAllAsync();
        Task<Part> GetByIdAsync(int partId);
    }
}
