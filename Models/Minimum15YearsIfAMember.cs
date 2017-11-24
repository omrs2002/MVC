using System;
using System.ComponentModel.DataAnnotations;

namespace MVCCourse2017.Models
{
    internal class Minimum15YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            //var cust =AutoMapper.Mapper.Map<CustomerDto,Customer>((CustomerDto)validationContext.ObjectInstance);
            var cust = ((Customer)validationContext.ObjectInstance);
            if (cust.MembershipTypeId == 1 || cust.MembershipTypeId == 0)
                return ValidationResult.Success;

            if (cust.Birthdate == null)
                return new ValidationResult("Birth Date is Rquired!");

            var Age = DateTime.Today.Year - cust.Birthdate.Year;

            return Age >= 18 ? ValidationResult.Success : new ValidationResult("Membership Age at least 18 Years old!");
        }
    }
}