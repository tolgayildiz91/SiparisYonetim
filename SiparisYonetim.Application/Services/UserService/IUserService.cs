using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Services.UserService
{
    public interface IUserService
    {
        Task<List<AppUser>> GetAllUsers();
        Task<bool> LoginAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<bool> Logout();
        Task<bool> UpdatePassword(string UserName, string newPassword);
        Task<AppUser> FindUserByNameAsync(string userName);
        Task<AppUser> FindUserByEmailAsync(string email);


        //Task<bool> CreateRoleAsync(AppRole roleName);

        //Task<bool> UpdateRoleAsync(AppRole roleDto);
        //Task<List<AppRole>> ListRolesAsync();
        //Task<AppRole> GetRoleByIdAsync(string roleId);
        //Task<bool> RoleExistAsync(string roleName);

        //Task<List<AppRole>> GetUserAllRoleAsync(long UserId);
        //Task<List<Manager>> GetRoleAllUserAsync(long RoleId);
        //Task<bool> DeleteUserRoleAsync(long UserId, long RoleId);
    }
}
