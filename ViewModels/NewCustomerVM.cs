using MVCCourse2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCourse2017.ViewModels
{
    public class NewCustomerVM
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}