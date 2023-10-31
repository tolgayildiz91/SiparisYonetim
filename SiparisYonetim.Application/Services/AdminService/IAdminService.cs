using SiparisYonetim.Application.Features.Admin.DTOs;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Services.AdminService
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAllAdmins();
        Task<Admin> GetAdminId(string adminId);
        Task<Admin> GetAdminByUserName(string username);
        Task<bool> CreateAdminAsync(CreateAdminDTO createAdminDTO);
        Task<bool> AddToRoleAsync(string userName, string roleName);
        Task<Admin> FindAdminByNameAsync(string userName);
        Task<Admin> FindAdminByEmailAsync(string email);
        Task<bool> UpdateAdminAsync(AdminDTO adminDTO, bool IsActive = true);

    }
}
