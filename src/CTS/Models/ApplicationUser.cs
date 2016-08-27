using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CTS.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }

        public string MailStreet1 { get; set; }
        public string MailStreet2 { get; set; }
        public string MailCity { get; set; }
        public string MailState { get; set; }
        public string MailZip { get; set; }

        public string PhysicalStreet1 { get; set; }
        public string PhysicalStreet2 { get; set; }
        public string PhysicalCity { get; set; }
        public string PhysicalState { get; set; }
        public string PhysicalZip { get; set; }
    }
}