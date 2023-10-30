using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiparisYonetim.Domain.Entities.Concrete;
using SiparisYonetim.Domain.Enums;
using SiparisYonetim.Domain.IRepositories;
using SiparisYonetim.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {

        private readonly SiparisYonetimDBContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        protected DbSet<Admin> _table;

        public AdminRepository(SiparisYonetimDBContext dbContext, UserManager<AppUser> userManager, DbSet<Admin> table)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _table = _dbContext.Set<Admin>();
        }

        public async Task<bool> Any(Expression<Func<Admin, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task Delete(Admin item)
        {
            item.Status = Status.Deleted;//Oluşturduğun entitynin status propertysinin değerini deleted yap
            await UpdateAdminAsync(item);
        }

        public async Task<Admin> FindAdminByEmailAsync(string email)
        {
            var AppUserResult = await _userManager.FindByEmailAsync(email);
            return await GetAdminId(AppUserResult.Id.ToString());
        }

        public async Task<Admin> FindAdminByNameAsync(string userName)
        {
            var AppUserResult = await _userManager.FindByNameAsync(userName);
            return await GetAdminId(AppUserResult.Id.ToString());
        }

        public Task<string> GeneratePassword()
        {
            const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string SpecialChars = "!@#$%&*()_-+=<>?";

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            // Bir büyük harf ekle
            password.Append(UppercaseChars[random.Next(UppercaseChars.Length)]);

            // Beş küçük harf ekle
            for (int i = 0; i < 5; i++)
            {
                password.Append(LowercaseChars[random.Next(LowercaseChars.Length)]);
            }

            // Bir özel sembol ekle
            password.Append(SpecialChars[random.Next(SpecialChars.Length)]);

            // Karakterleri karıştır
            string shuffledPassword = new string(password.ToString().OrderBy(c => random.Next()).ToArray());

            return await Task.FromResult(shuffledPassword);
        }

        public async Task<Admin> GetAdminId(string adminId)
        {
            return await _table.FindAsync(adminId);
        }

        public async Task<List<Admin>> GetAllAdmin()
        {
            return await _table.ToListAsync();
        }

        public async Task<List<Admin>> GetDefaults(Expression<Func<Admin, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<bool> UpdateAdminAsync(Admin admin, bool IsActive = true)
        {
            _dbContext.Entry<Admin>(admin).State = EntityState.Modified;//Güncelleme Yap
            var result = await _dbContext.SaveChangesAsync();
            if (result > 1)
            {
                return true;
            }
            return false;
        }
    }
}
