using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Job { get; set; } //User' main profession
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? Language { get; set; } //Teachers can give global lessons or students can ask a lesson in another language
        public string Mail { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? AvatarUrl { get; set; } // Profile Picture
        

    }
}
