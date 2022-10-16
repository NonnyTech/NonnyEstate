using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nonny_Estate.Models
{
    public class ApplicationUser : IdentityUser
    {
        
       
            public string FirstName { get; set; }
            public string LastName { get; set; }
        public int NoOfCars { get; internal set; }
    }
    }
