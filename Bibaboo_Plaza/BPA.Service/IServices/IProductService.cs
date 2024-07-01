using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Service.IServices
{
    public interface IProductService
    {
        IEnumerable<Product> SearchByName(string name);
        IEnumerable<Product> GetAll();
        Product? GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Update2(Product product);
        void Delete(Product product);
    }
}
