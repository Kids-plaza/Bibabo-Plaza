using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.DAO
{
    public class OrderDAO : BaseDAO<Order>
    {
        private static OrderDAO instance = null;
        private static readonly object lockObject = new();
        public OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance != null)
                    {
                        return instance;
                    }
                    instance = new OrderDAO();
                    return instance;
                }
            }
        }
    }
}
