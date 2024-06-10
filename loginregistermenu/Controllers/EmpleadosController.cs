using Microsoft.AspNetCore.Mvc;
using loginregistermenu.Data;
using loginregistermenu.Models;
using System.Threading.Tasks;

namespace loginregistermenu.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegistrarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(empleado);
        }
    }
}

