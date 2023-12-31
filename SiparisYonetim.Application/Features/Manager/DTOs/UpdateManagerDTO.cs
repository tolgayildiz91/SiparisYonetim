﻿using SiparisYonetim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Manager.DTOs
{
    public class UpdateManagerDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Picture { get; set; }
        public string FirstName { get; set; }
        public string? SecondFirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public Gender? Gender { get; set; }


        public int BranchID { get; set; }


        public string? ModifiedBy { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
