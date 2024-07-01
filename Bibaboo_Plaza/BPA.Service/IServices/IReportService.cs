using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Service.IServices
{
    public interface IReportService
    {
        IEnumerable<Report> GetAll();
        Report? GetById(Guid id);
        void Add(Report report);
        void Update(Report report);
        void Delete(Report report);
    }
}
