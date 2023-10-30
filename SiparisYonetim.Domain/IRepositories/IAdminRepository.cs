using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Domain.IRepositories
{
    public interface IAdminRepository
    {
        Task<Admin> FindAdminByEmailAsync(string email);
        Task<Admin> FindAdminByNameAsync(string userName);
        Task<List<Admin>> GetAllAdmin();
        Task<Admin> GetAdminId(string adminId);
        Task<bool> UpdateAdminAsync(Admin admin, bool IsActive = true);


        Task Delete(Admin item);
        Task<string> GeneratePassword();
        Task<List<Admin>> GetDefaults(Expression<Func<Admin, bool>> expression);
        Task<bool> Any(Expression<Func<Admin, bool>> expression);
    }
}
