using CrowdFunding.BLL.Mappers;
using CrowdFunding.BLL.Models;
using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Repositories;
using CrowdFunding.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services.Implementations
{
    public class BankAccountService : IBankAccountService<int, BankAccountBO>
    {
        private IBankAccountRepository<int, BankAccount> _bankAccountRepository;
        public BankAccountService()
        {
            _bankAccountRepository = new BankAccountRepository();
        }

        public bool Delete(int id)
        {
            return _bankAccountRepository.Delete(id);
        }

        public IEnumerable<BankAccountBO> GetAll()
        {
            return _bankAccountRepository.GetAll().Select(l => l.MapTo<BankAccountBO>());
        }

        public BankAccountBO GetById(int id)
        {
            return _bankAccountRepository.GetById(id).MapTo<BankAccountBO>();
        }

        public BankAccountBO GetByProject(int projectId)
        {
            return _bankAccountRepository.GetByProject(projectId).MapTo<BankAccountBO>();
        }

        public int Save(BankAccountBO entity)
        {
            return _bankAccountRepository.Insert(entity.MapTo<BankAccount>());
        }

        public bool Update(int id, BankAccountBO entity)
        {
            BankAccount bankAccount = entity.MapTo<BankAccount>();
            bankAccount.Id = id;
            return _bankAccountRepository.Update(bankAccount);
        }
    }
}
