using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly082018.Models;

namespace Vidly082018.ViewModels
{
    public class CustomerFormViewModel
    {

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}