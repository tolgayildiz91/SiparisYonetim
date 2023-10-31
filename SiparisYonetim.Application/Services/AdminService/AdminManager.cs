using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SiparisYonetim.Application.Features.Admin.DTOs;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Application.Services.ManagerService;
using SiparisYonetim.Domain.Entities.Concrete;
using SiparisYonetim.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Services.AdminService
{
    public class AdminManager : IAdminService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAdminRepository _adminRepository;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AdminManager(UserManager<AppUser> userManager, IAdminRepository adminRepository, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _adminRepository = adminRepository;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<bool> AddToRoleAsync(string userName, string roleName)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.GetType().FullName + " => " + ex.GetType().Assembly.GetName().Version.ToString() + " Hata => " + ex.Message);
                return false;
            }
        }

        //kontrol et
        public async Task<bool> CreateAdminAsync(CreateAdminDTO createAdminDTO)
        {
            try
            {
                var admin = _mapper.Map<Admin>(createAdminDTO);
                return await _adminRepository.AddAsync(admin);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Admin> FindAdminByEmailAsync(string email)
        {
            return await _adminRepository.FindAdminByEmailAsync(email);


        }

        public async Task<Admin> FindAdminByNameAsync(string userName)
        {
            return await _adminRepository.FindAdminByNameAsync(userName);
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            return await _adminRepository.GetAllAdmin();
        }

        public async Task<Admin> GetAdminByUserName(string username)
        {
            return await _adminRepository.FindAdminByNameAsync(username);
        }

        public async Task<Admin> GetAdminId(string adminId)
        {
            return await _adminRepository.GetAdminId(adminId);
        }

        public async Task<bool> UpdateAdminAsync(AdminDTO adminDTO, bool IsActive = true)
        {
            return await _adminRepository.UpdateAdminAsync(_mapper.Map<Admin>(adminDTO), IsActive);
        }
    }
}
