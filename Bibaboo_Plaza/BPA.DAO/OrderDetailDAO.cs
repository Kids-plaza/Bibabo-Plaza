using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.DAO
{
    public class OrderDetailDAO : BaseDAO<OrderDetail>
    {
        private static OrderDetailDAO instance = null;
        private static readonly object lockObject = new();
        public OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance != null)
                    {
                        return instance;
                    }
                    instance = new OrderDetailDAO();
                    return instance;
                }
            }
        }
    }
}
