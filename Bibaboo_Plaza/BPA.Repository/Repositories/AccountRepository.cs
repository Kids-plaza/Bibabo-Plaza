using BPA.BusinessObject.Dtos.Account;
using BPA.BusinessObject.Entities;
using BPA.DAO;
using BPA.Repository.IRepositories;

namespace BPA.Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public void Add(Account account) => AccountDAO.Instance.Add(account);

        public void Delete(Account account) => AccountDAO.Instance.Delete(account);

        public IEnumerable<Account> GetAll() => AccountDAO.Instance.GetAll();

        public Account? GetById(Guid id) => AccountDAO.Instance.GetById(id);

        public void Update(Account account) => AccountDAO.Instance.Update(account);
        public void Update2(Account account) => AccountDAO.Instance.Update2(account, GetById(account.Id));
    }
}
