﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder.Models.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Description { get; set; }
        public string AddressDetail { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OpeningHours { get; set; }
    }
}