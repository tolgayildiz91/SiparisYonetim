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
    public class ManagerRepository : IManagerRepository
    {
        private readonly SiparisYonetimDBContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        protected DbSet<Manager> _table;

        public ManagerRepository(SiparisYonetimDBContext dbContext, DbSet<Manager> table, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Manager>();
            _userManager = userManager;
        }

        public async Task<bool> Any(Expression<Func<Manager, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task Delete(Manager item)
        {
            item.Status = Status.Deleted;//Oluşturduğun entitynin status propertysinin değerini deleted yap
            await UpdateManagerAsync(item);
        }

        public async Task<string> GeneratePassword()
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

        public async Task<List<Domain.Entities.Concrete.Manager>> GetAllManagers()
        {
           return await _table.ToListAsync();
        }

        public async Task<List<Manager>> GetDefaults(Expression<Func<Manager, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<Domain.Entities.Concrete.Manager> GetManagerId(string managerId)
        {
           return await _table.FindAsync(managerId);
        }

        public async Task<bool> UpdateManagerAsync(Domain.Entities.Concrete.Manager manager, bool IsActive = true)
        {
            _dbContext.Entry<Manager>(manager).State = EntityState.Modified;//Güncelleme Yap
             var result = await _dbContext.SaveChangesAsync();
            if (result > 1)
            {
                return true;
            }
            return false;
            
        }
        public async Task<Domain.Entities.Concrete.Manager> FindManagerByEmailAsync(string email)
        {
            var AppUserResult = await _userManager.FindByEmailAsync(email);
            return await GetManagerId(AppUserResult.Id.ToString());
        }

        public async Task<Domain.Entities.Concrete.Manager> FindManagerByNameAsync(string userName)
        {
            var AppUserResult = await _userManager.FindByNameAsync(userName);
            return await GetManagerId(AppUserResult.Id.ToString());
        }

        public async Task<bool> AddAsync(Manager item)
        {

            await _userManager.CreateAsync(item, await GeneratePassword());
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
