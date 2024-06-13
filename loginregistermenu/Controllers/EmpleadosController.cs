using Microsoft.AspNetCore.Mvc;
using loginregistermenu.Data;
using loginregistermenu.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

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
        public async Task<IActionResult> RegistrarEmpleado()
        {
            ViewData["Generos"] = await _context.Generos.ToListAsync();
            ViewData["EstadoCiviles"] = await _context.EstadoCiviles.ToListAsync();
            ViewData["EstadoPersonas"] = await _context.EstadoPersonas.ToListAsync();
            ViewData["PuestosEmpleados"] = await _context.PuestosEmpleados.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Personas.Add(empleado.Persona);
                await _context.SaveChangesAsync();

                empleado.PersonaID = empleado.Persona.PersonaID;
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            ViewData["Generos"] = await _context.Generos.ToListAsync();
            ViewData["EstadoCiviles"] = await _context.EstadoCiviles.ToListAsync();
            ViewData["EstadoPersonas"] = await _context.EstadoPersonas.ToListAsync();
            ViewData["PuestosEmpleados"] = await _context.PuestosEmpleados.ToListAsync();

            return View(empleado);
        }
    }
}
