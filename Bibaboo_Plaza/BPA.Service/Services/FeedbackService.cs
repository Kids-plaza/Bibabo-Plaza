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
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public void Add(Feedback feedback)
        {
            _feedbackRepository.Add(feedback);
        }

        public void Delete(Feedback feedback)
        {
            _feedbackRepository.Delete(feedback);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback? GetById(Guid id)
        {
            return _feedbackRepository.GetById(id);
        }

    }
}
