using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopAspnetCore.Data;
using WorkshopAspnetCore.Models;

namespace WorkshopAspnetCore.Controllers
{
    [Route("api/pessoas")]
    public class PessoasController : Controller
    {
        private DataContext _context;

        public PessoasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.Pessoas.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CriarPessoa([FromBody] Pessoa model)
        {
            await _context.Pessoas.AddAsync(model);
            await _context.SaveChangesAsync();

            return Json(model);
        }
    }
}
