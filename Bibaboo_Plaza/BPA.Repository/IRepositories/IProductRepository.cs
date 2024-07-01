using BPA.BusinessObject.Entities;

namespace BPA.Repository.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Update2(Product product);
        void Delete(Product product);
    }
}
