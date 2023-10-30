using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Domain.Entities.Abstract;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Services.ManagerService
{
    public interface IManagerService
    {
        Task<List<Manager>> GetAllManagers();
        Task<Manager> GetUserId(string managerId);
        Task<Manager> GetUserByUserName(string username);
        Task<bool> CreateManagerAsync(CreateManagerDTO createManagerDTO);
        Task<bool> AddToRoleAsync(string userName, string roleName);
        Task<Manager> FindManagerByNameAsync(string userName);
        Task<Manager> FindManagerByEmailAsync(string email);
        Task<bool> UpdateManagerAsync(ManagerDTO userdto, bool IsActive = true);
     
        
  

  



       


    }
}
