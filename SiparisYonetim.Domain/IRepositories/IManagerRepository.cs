using SiparisYonetim.Domain.Entities.Abstract;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Domain.IRepositories
{
    public interface IManagerRepository
    {
        Task<Manager> FindManagerByEmailAsync(string email);
        Task<Manager> FindManagerByNameAsync(string userName);
        Task<List<Manager>> GetAllManagers();
        Task<Manager> GetManagerId(string managerId);
        Task<bool> UpdateManagerAsync(Manager manager, bool IsActive = true);


        Task Delete(Manager item);
        Task<string> GeneratePassword();
        Task<List<Manager>> GetDefaults(Expression<Func<Manager, bool>> expression);
        Task<bool> Any(Expression<Func<Manager, bool>> expression);
        Task Add(Manager item);
    }
}