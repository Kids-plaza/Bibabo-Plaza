using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Repository.IRepositories
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        Feedback? GetById(Guid id);
        void Add(Feedback feedback);
        void Delete(Feedback feedback);
    }
}
