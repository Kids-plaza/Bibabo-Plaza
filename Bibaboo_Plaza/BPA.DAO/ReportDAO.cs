using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.DAO
{
    public class ReportDAO : BaseDAO<Report>
    {
        private static ReportDAO instance = null;
        private static readonly object lockObject = new();

        public ReportDAO()
        {
        }
        public static ReportDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance != null)
                    {
                        return instance;
                    }
                    instance = new ReportDAO();
                    return instance;
                }
            }
        }
    }
}
