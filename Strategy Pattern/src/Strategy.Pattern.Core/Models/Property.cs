﻿using Strategy.Pattern.Public.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Pattern.Core.Models
{
    public class Property
    {
        public string Address { get; set; }

        public AgencyCode AgencyCode { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
