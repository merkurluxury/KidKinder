﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models.Entities
{
    public class Service
    {
        
        public int ServiceId { get; set; }
        public string  Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}