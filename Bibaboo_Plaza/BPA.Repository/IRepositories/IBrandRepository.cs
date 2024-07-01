using BPA.BusinessObject.Entities;

namespace BPA.Repository.IRepositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        Brand? GetById(Guid id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
