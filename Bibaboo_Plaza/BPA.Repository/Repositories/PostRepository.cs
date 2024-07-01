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
    public class PostRepository : IPostRepository
    {
        public void Add(Post post) => PostDAO.Instance.Add(post);

        public void Delete(Post post) => PostDAO.Instance.Delete(post);

        public IEnumerable<Post> GetAll() => PostDAO.Instance.GetAll();

        public Post? GetById(Guid id) => PostDAO.Instance.GetById(id);

        public void Update(Post post) => PostDAO.Instance.Update(post);
    }
}
