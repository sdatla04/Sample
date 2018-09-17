using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly082018.Dtos
{
    public class CustomerDto
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Please enter customer name")]
        [StringLength(255)]
        public string Name { get; set; }

        //Min18YearsForMembership -> Custom Validation
       //[Min18YearsForMembership]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //Create a membershipDto to decouple Customer and MembershipType domain objects
       // public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

    }
}