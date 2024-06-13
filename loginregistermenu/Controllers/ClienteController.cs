using Microsoft.AspNetCore.Mvc;
using loginregistermenu.Data;
using loginregistermenu.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace loginregistermenu.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCliente(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Rol = "cliente"; // Asignar rol predeterminado
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Usuario");
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> EditarPerfil()
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Persona)
                .FirstOrDefaultAsync(u => u.Correo == User.Identity.Name);

            if (usuario == null)
            {
                return NotFound();
            }

            ViewData["Generos"] = await _context.Generos.ToListAsync();
            ViewData["EstadoCiviles"] = await _context.EstadoCiviles.ToListAsync();
            ViewData["EstadoPersonas"] = await _context.EstadoPersonas.ToListAsync();
            ViewData["TipoTelefonos"] = await _context.TiposTelefono.ToListAsync();
            ViewData["TipoDirecciones"] = await _context.TiposDireccion.ToListAsync();

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> EditarPerfil(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            ViewData["Generos"] = await _context.Generos.ToListAsync();
            ViewData["EstadoCiviles"] = await _context.EstadoCiviles.ToListAsync();
            ViewData["EstadoPersonas"] = await _context.EstadoPersonas.ToListAsync();
            ViewData["TipoTelefonos"] = await _context.TiposTelefono.ToListAsync();
            ViewData["TipoDirecciones"] = await _context.TiposDireccion.ToListAsync();

            return View(usuario);
        }
    }
}
