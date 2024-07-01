using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Repository.IRepositories
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetAll();
        Report GetById(Guid id);
        void Add(Report report);
        void Update(Report report);
        void Delete(Report report);
    }
}
