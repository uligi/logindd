using Microsoft.AspNetCore.Mvc;
using loginregistermenu.Data;
using loginregistermenu.Models;
using System.Threading.Tasks;

namespace loginregistermenu.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegistrarProducto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(producto);
        }
    }
}
