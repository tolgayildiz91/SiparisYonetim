using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiparisYonetim.Domain.Entities.Abstract;
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

            public ManagerRepository(SiparisYonetimDBContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Manager>();
            _userManager = userManager;


        }

        public async Task<bool> Any(Expression<Func<Manager, bool>> expression)
        {
            return await _table.AnyAsync(expression);
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

        public async Task<Domain.Entities.Concrete.Manager> GetManagerId(Guid managerId)
        {
           return await _table.FindAsync(managerId);
        }

        public async Task Delete(Manager item)
        {
            var existingManager = await _dbContext.Set<Manager>().FirstOrDefaultAsync(m => m.Id == item.Id);
            if (existingManager != null)
            {
                existingManager.ModifiedBy = item.ModifiedBy;
                existingManager.ModifiedDate = item.ModifiedDate;
                existingManager.Status = Status.Deleted;//Oluşturduğun entitynin status propertysinin değerini deleted yap
            }

            _dbContext.Entry<Manager>(existingManager).State = EntityState.Modified;//Güncelleme Yap

            await _dbContext.SaveChangesAsync();

        }
        public async Task<bool> UpdateManagerAsync(Domain.Entities.Concrete.Manager manager, bool IsActive = true)
        {

            try
            {
                var existingManager = await _dbContext.Set<Manager>().FirstOrDefaultAsync(m => m.Id == manager.Id);
                if (existingManager != null)
                {
                    existingManager.Picture = manager.Picture;
                    existingManager.FirstName = manager.FirstName;
                    existingManager.SecondFirstName = manager.SecondFirstName;
                    existingManager.LastName = manager.LastName;
                    existingManager.SecondLastName = manager.SecondLastName;
                    existingManager.Gender = manager.Gender;
                    existingManager.ModifiedBy = manager.ModifiedBy;
                    existingManager.ModifiedDate = manager.ModifiedDate;
                    existingManager.Status = manager.Status;
                    existingManager.BranchID = manager.BranchID;
                }

                _dbContext.Entry<Manager>(existingManager).State = EntityState.Modified;//Güncelleme Yap
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Hata durumunda uygun bir şekilde işleyin veya loglayın
                return false;
            }

        }
        public async Task<Domain.Entities.Concrete.Manager> FindManagerByEmailAsync(string email)
        {
            var AppUserResult = await _userManager.FindByEmailAsync(email);
            return await GetManagerId(AppUserResult.Id);
        }

        public async Task<Domain.Entities.Concrete.Manager> FindManagerByNameAsync(string userName)
        {
            var AppUserResult = await _userManager.FindByNameAsync(userName);
            return await GetManagerId(AppUserResult.Id);
        }

        public async Task<bool> AddAsync(Manager item)
        {

            await _userManager.CreateAsync(item, await GeneratePassword());
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
