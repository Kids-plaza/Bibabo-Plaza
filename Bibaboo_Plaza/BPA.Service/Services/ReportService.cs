using BPA.BusinessObject.Entities;
using BPA.Repository.IRepositories;
using BPA.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public void Add(Report report)
        {
            _reportRepository.Add(report);
        }

        public void Delete(Report report)
        {
            _reportRepository.Delete(report);
        }

        public IEnumerable<Report> GetAll()
        {
            return _reportRepository.GetAll();
        }

        public Report? GetById(Guid id)
        {
            return _reportRepository.GetById(id);
        }

        public void Update(Report report)
        {
            _reportRepository.Update(report);
        }
    }
}
