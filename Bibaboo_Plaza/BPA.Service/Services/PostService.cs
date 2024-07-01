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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(Post post)
        {
            _postRepository.Delete(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post? GetById(Guid id)
        {
            return _postRepository.GetById(id);
        }

        public IEnumerable<Post> SearchByTitle(string name)
        {
            return _postRepository.GetAll().Where(x => x.Title!.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
