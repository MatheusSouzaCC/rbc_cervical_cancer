using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rbc.Data;
using Rbc.Models;

namespace Rbc.Controllers
{
    public class RbcController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public RbcController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var retorno = _context.Casos.Where(c => c.Origem == OrigemCaso.Dataset).Take(10).ToList();
            return View(retorno);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
