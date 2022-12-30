using System.Linq;
using System.Threading.Tasks;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly EstoqueWebContext _context;

        public CategoriaController(EstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
        }
    }
}