using BPA.BusinessObject.Entities;
using BPA.DAO;
using BPA.Repository.IRepositories;

namespace BPA.Repository.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public void Add(Brand brand) => BrandDAO.Instance.Add(brand);

        public void Delete(Brand brand) => BrandDAO.Instance.Delete(brand);

        public IEnumerable<Brand> GetAll() => BrandDAO.Instance.GetAll();

        public Brand? GetById(Guid id) => BrandDAO.Instance.GetById(id);

        public void Update(Brand brand) => BrandDAO.Instance.Update(brand);
    }
}
