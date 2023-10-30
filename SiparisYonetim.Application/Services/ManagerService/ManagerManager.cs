﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Domain.Entities.Abstract;
using SiparisYonetim.Domain.Entities.Concrete;
using SiparisYonetim.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Services.ManagerService
{
    public class ManagerManager : IManagerService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IManagerRepository _managerRepository;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public ManagerManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, Domain.IRepositories.IManagerRepository managerRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _managerRepository = managerRepository;
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
        public async Task<bool> CreateManagerAsync(CreateManagerDTO createManagerDTO)
        {
            try
            {
                var manager = _mapper.Map<Manager>(createManagerDTO);

                var passwordHasher = new PasswordHasher<Manager>();
                manager.PasswordHash = passwordHasher.HashPassword(manager, createManagerDTO.Password);



                var result = await _managerRepository.(manager, createManagerDTO.Password);
                if (!result.Succeeded)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Manager> FindManagerByEmailAsync(string email)
        {
            return await _managerRepository.FindManagerByEmailAsync(email);
          
           
        }

        public async Task<Manager> FindManagerByNameAsync(string userName)
        {
            return await _managerRepository.FindManagerByNameAsync(userName);
        }

        public async Task<List<Manager>> GetAllManagers()
        {
            return await _managerRepository.GetAllManagers();
        }

        public async Task<Manager> GetUserByUserName(string username)
        {
            return await _managerRepository.FindManagerByNameAsync(username);
        }

        public async Task<Manager> GetUserId(string managerId)
        {
            return await _managerRepository.GetManagerId(managerId);
        }

        public async Task<bool> UpdateManagerAsync(ManagerDTO userdto, bool IsActive = true)
        {
            return await _managerRepository.UpdateManagerAsync(_mapper.Map<Manager>(userdto), IsActive);
        }
    }
}