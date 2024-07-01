using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Repository.IRepositories
{
    public interface IOrderDetailRepository
    {
        void Add(OrderDetail orderDetail);
        void Delete(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetAll();
        OrderDetail? GetById(Guid id);
        void Update(OrderDetail orderDetail);
    }
}
