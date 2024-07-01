using BPA.BusinessObject.Entities;
using BPA.Repository.IRepositories;
using BPA.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void Add(Brand brand)
        {
            _brandRepository.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandRepository.Delete(brand);
        }

        public IEnumerable<Brand> GetAll()
        {
            return _brandRepository.GetAll();
        }

        public Brand? GetById(Guid id)
        {
            return _brandRepository.GetById(id);
        }

        public IEnumerable<Brand> SearchByName(string name)
        {
            return _brandRepository.GetAll().Where(x => x.BrandName!.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Update(Brand brand)
        {
            _brandRepository.Update(brand);
        }
    }
}
