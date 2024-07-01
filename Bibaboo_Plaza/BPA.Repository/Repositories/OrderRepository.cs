using BPA.BusinessObject.Entities;
using BPA.DAO;
using BPA.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order) => OrderDAO.Instance.Add(order);

        public void Delete(Order order) => OrderDAO.Instance.Delete(order);

        public IEnumerable<Order> GetAll() => OrderDAO.Instance.GetAll();

        public Order? GetById(Guid id) => OrderDAO.Instance.GetById(id);

        public void Update(Order order) => OrderDAO.Instance.Update(order);

        public void Update2(Order order) => OrderDAO.Instance.Update2(order, GetById(order.Id));
    }
}
