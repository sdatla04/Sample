using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly082018.Models
{
    public class Customer
    {
        public int id { get; set; }

        // The approach of overwriting the default conventions is called Data Annotations
        //Required -> Data Annotation specifies the migration that the following field 
        // is NOT Nullable as by default String datat type is NULLABLE in Database
        //StringLength -> Data Annotation specifies the limit on string lenght in DB 
        
        [Required(ErrorMessage = "Please enter customer name")]     
        [StringLength(255)]
        public string Name { get; set; }

        //Display -> Data Annotation to Display Custom Label  in UI
        [Display(Name="Date of Birth")]
        //Min18YearsForMembership -> Custom Validation
        [Min18YearsForMembership]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
       
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        //Added to test GIT commit
       // public bool? IsValid { get; set; }



    }


    public class Min18YearsForMembership:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.PayAsYouGo   || customer.MembershipTypeId == MembershipType.Unknown)
                return ValidationResult.Success;

            if (customer.Birthdate == null )
                return new ValidationResult("Birth Date is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("You have to be 18 years old to have a membership.");

        }
    }
}