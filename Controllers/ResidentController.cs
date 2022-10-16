using Microsoft.AspNetCore.Mvc;
using Nonny_Estate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nonny_Estate.Controllers
{
    public class ResidentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResidentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
