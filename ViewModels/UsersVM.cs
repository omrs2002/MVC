using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCourse2017.ViewModels
{
    public class UsersVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string DrivingLicense { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
    }
}