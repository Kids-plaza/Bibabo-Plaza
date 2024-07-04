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
    public class FeedbackRepository : IFeedbackRepository
    {
        public void Add(Feedback feedback) => FeedbackDAO.Instance.Add(feedback);

        public void Delete(Feedback feedback) => FeedbackDAO.Instance.Delete(feedback);

        public IEnumerable<Feedback> GetAll() => FeedbackDAO.Instance.GetAll();

        public Feedback? GetById(Guid id) => FeedbackDAO.Instance.GetById(id);

        public void Update(Feedback feedback) => FeedbackDAO.Instance.Update(feedback);

    }
}
