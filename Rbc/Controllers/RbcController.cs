using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rbc.Data;
using Rbc.Models;
using Rbc.Models.Util;

namespace Rbc.Controllers
{
    public class RbcController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public RbcController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page, int qtd = 40)
        {
            if (page < 0)
                page = 1;

            var retorno = _context.Casos.Where(c => c.Origem == OrigemCaso.Dataset);
            return View(await PaginatedList<Caso>.CreateAsync(retorno.AsNoTracking(), page ?? 1, qtd));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
