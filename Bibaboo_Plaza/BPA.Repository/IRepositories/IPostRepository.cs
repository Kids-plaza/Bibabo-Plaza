using BPA.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Repository.IRepositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post GetById(Guid id);
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}
