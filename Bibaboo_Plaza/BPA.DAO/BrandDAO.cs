using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.DAO
{
    public class BrandDAO: BaseDAO<Brand>
    {
        private static BrandDAO instance = null;
        private static readonly object lockObject = new();

        public BrandDAO()
        {
        }
        public static BrandDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance != null)
                    {
                        return instance;
                    }
                    instance = new BrandDAO();
                    return instance;
                }
            }
        }
    }
}
