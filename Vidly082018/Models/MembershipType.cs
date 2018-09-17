﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly082018.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public static readonly byte Unknown = 0;

        public static readonly byte PayAsYouGo = 1;
    }
}