using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.DAO
{
    public class PostDAO: BaseDAO<Post>
    {
        private static PostDAO instance = null;
        private static readonly object lockObject = new();

        public PostDAO()
        {
        }
        public static PostDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance != null)
                    {
                        return instance;
                    }
                    instance = new PostDAO();
                    return instance;
                }
            }
        }
    }
}
