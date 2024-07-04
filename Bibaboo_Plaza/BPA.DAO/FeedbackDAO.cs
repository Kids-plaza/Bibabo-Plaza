using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.DAO
{
    public class FeedbackDAO : BaseDAO<Feedback>
    {
        private static FeedbackDAO instance = null;
        private static readonly object lockObject = new();
        public FeedbackDAO() { }
        public static FeedbackDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance != null)
                    {
                        return instance;
                    }
                    instance = new FeedbackDAO();
                    return instance;
                }
            }
        }
    }
}
