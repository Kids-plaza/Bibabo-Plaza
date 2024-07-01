using BPA.BusinessObject.Dtos.Account;
using BPA.BusinessObject.Entities;

namespace BPA.Service.IServices
{
    public interface IAccountService
    {
        Account? GetAccountByEmailAndPassword(AccountLoginDto accountLoginDto);
        IEnumerable<Account> SearchByName(string name);
        IEnumerable<Account> GetAll();
        Account? GetById(Guid id);
        void Add(Account account);
        void Update(Account account);
        void Update2(Account account);
        void Delete(Account account);
    }
}
