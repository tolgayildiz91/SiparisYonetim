using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Infrastructure.DataAccess
{
    public class SiparisYonetimDBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public SiparisYonetimDBContext(DbContextOptions options) : base(options){ }


        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();




            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Admin>().ToTable("Admin");
            builder.Entity<Manager>().ToTable("Managers");



            base.OnModelCreating(builder);
        }

    }
}
