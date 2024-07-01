using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Service.IServices
{
    public interface IBrandService
    {
        IEnumerable<Brand> SearchByName(string name);
        IEnumerable<Brand> GetAll();
        Brand? GetById(Guid id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
