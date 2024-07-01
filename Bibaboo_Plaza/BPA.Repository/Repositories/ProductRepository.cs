using BPA.BusinessObject.Entities;
using BPA.DAO;
using BPA.Repository.IRepositories;

namespace BPA.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product) => ProductDAO.Instance.Add(product);

        public void Delete(Product product) => ProductDAO.Instance.Delete(product);

        public IEnumerable<Product> GetAll() => ProductDAO.Instance.GetAll();

        public Product GetById(Guid id) => ProductDAO.Instance.GetById(id);

        public void Update(Product product) => ProductDAO.Instance.Update(product);
        public void Update2(Product product) => ProductDAO.Instance.Update2(product, GetById(product.Id));
    }
}
