using BPA.BusinessObject.Entities;

namespace BPA.Service.IServices
{
    public interface IOrderService
    {
        void Add(Order order);
        void Delete(Order order);
        IEnumerable<Order> GetAll();
        Order? GetById(Guid id);
        void Update(Order order);
        void Update2(Order order);
    }
}
