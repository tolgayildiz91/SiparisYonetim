using Microsoft.AspNetCore.Identity;
using SiparisYonetim.Domain.Entities.Abstract;
using SiparisYonetim.Domain.Enums;

namespace SiparisYonetim.Domain.Entities.Concrete
{
    public class AppUser : IdentityUser<Guid>, IUser
    {
        public string? Picture { get; set ; }
        public string FirstName { get; set; }
        public string? SecondFirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public Gender? Gender { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
