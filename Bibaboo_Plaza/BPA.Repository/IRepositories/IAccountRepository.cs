using BPA.BusinessObject.Dtos.Account;
using BPA.BusinessObject.Entities;

namespace BPA.Repository.IRepositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account? GetById(Guid id);
        void Add(Account account);
        void Update(Account account);
        void Update2(Account account);
        void Delete(Account account);
    }
}
