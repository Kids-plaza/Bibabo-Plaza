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
    public class ReportRepository : IReportRepository
    {
        public void Add(Report report) => ReportDAO.Instance.Add(report);

        public void Delete(Report report) => ReportDAO.Instance.Delete(report);

        public IEnumerable<Report> GetAll() => ReportDAO.Instance.GetAll();

        public Report? GetById(Guid id) => ReportDAO.Instance.GetById(id);

        public void Update(Report report) => ReportDAO.Instance.Update(report);
    }
}
